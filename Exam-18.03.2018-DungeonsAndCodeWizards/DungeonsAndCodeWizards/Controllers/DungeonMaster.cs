namespace DungeonsAndCodeWizards.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Factories;
    using Models.Characters;
    using Models.Interfaces;
    using Models.Items;

    public class DungeonMaster
    {
        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;
        private List<Character> characters;
        private Stack<Item> items;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character = this.characterFactory.CreateCharacter(args[0], args[1], args[2]);
            this.characters.Add(character);
            return $"{args[2]} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            Item item = this.itemFactory.CreateItem(args[0]);
            this.items.Push(item);
            return $"{args[0]} added to pool.";
        }

        // Check for ERROR
        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.FindCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            
            Item item = this.items.Pop();
            character.Bag.AddItem(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }
        
        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.FindCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giverCharacter = this.FindCharacter(giverName);
            Character receiverCharacter = this.FindCharacter(receiverName);
            Item item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.UseItemOn(item, receiverCharacter);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giverCharacter = this.FindCharacter(giverName);
            Character receiverCharacter = this.FindCharacter(receiverName);
            Item item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.GiveCharacterItem(item, receiverCharacter);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Character character in this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerCharacter = this.FindCharacter(attackerName);
            Character receiverCharacter = this.FindCharacter(receiverName);

            if (!(attackerCharacter is IAttackable attacker))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            attacker.Attack(receiverCharacter);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! {receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!");

            if (!receiverCharacter.IsAlive)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healerCharacter = this.FindCharacter(healerName);
            Character receiverCharacter = this.FindCharacter(healingReceiverName);

            if (!(healerCharacter is IHealable healer))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healer.Heal(receiverCharacter);
            return $"{healerName} heals {healingReceiverName} for {healerCharacter.AbilityPoints}! {receiverCharacter.Name} has {receiverCharacter.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Character character in this.characters.Where(c => c.IsAlive))
            {
                double oldHealth = character.Health;
                character.Rest();

                sb.AppendLine($"{character.Name} rests ({oldHealth} => {character.Health})");
            }

            if (this.characters.Count(c => c.IsAlive) <= 1)
            {
                this.lastSurvivorRounds++;
            }
            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            return this.characters.Count(c => c.IsAlive) <= 1 && this.lastSurvivorRounds > 1;
        }

        private Character FindCharacter(string name)
        {
            Character character = this.characters.FirstOrDefault(c => c.Name == name);
            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }
            return character;
        }
    }
}
