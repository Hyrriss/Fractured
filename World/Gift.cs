using System;
using System.Collections.Generic;
using System.Text;

namespace Fractured.World
{
    public class Gift
    {
        public int ID { get { return id; } }
        private readonly int id;
        public string Name { get { return name; } }
        private readonly string name;
        public bool IsRollable { get { return isRollable; } }
        private readonly bool isRollable;
        private readonly Dictionary<int, GiftReaction> characterReactions;
        public string Description { get { return descript; } }
        private readonly string descript;
        private readonly bool giftable;

        /// <summary>
        /// Creates a new gift witout any reactions
        /// </summary>
        /// <param name="giftID">ID Number of the gift - Affects the position of the gift on the collection menu</param>
        /// <param name="giftName">Name of the gift - Displayed on the collection menu</param>
        /// <param name="canBeBought">Whether or not the gift can be obtained from the Monomono Machine</param>
        /// <param name="description">Description of the gift - Displayed on the collection menu</param>
        /// <param name="canBeGifted">Whether the gift can be gifted or not. If set to 'true', the item will provoke a neutral reaction from all characters</param>
        public Gift(int giftID, string giftName, bool canBeBought, string description, bool canBeGifted = false)
        {
            id = giftID;
            name = giftName;
            isRollable = canBeBought;
            descript = description;
            giftable = canBeGifted;
        }

        /// <summary>
        /// Creates a new gift with the same reaction from all characters
        /// </summary>
        /// <param name="giftID">ID Number of the gift - Affects the position of the gift on the collection menu</param>
        /// <param name="giftName">Name of the gift - Displayed on the collection menu</param>
        /// <param name="canBeBought">Whether or not the gift can be obtained from the Monomono Machine</param>
        /// <param name="description">Description of the gift - Displayed on the collection menu</param>
        /// <param name="universalReaction">The reaction to provoke from all characters upon gifting</param>
        public Gift(int giftID, string giftName, bool canBeBought, string description, GiftReaction universalReaction)
        {
            id = giftID;
            name = giftName;
            isRollable = canBeBought;
            descript = description;
            characterReactions = new Dictionary<int, GiftReaction>();
            for (int i = 2; i <= 18; i++) { characterReactions.Add(i, universalReaction); }
            giftable = true;
        }

        /// <summary>
        /// Creates a new gift with different reactions from all characters
        /// </summary>
        /// <remarks>Characters not listed in reactionsToGift will be set to neutral reaction</remarks>
        /// <param name="giftID">ID Number of the gift - Affects the position of the gift on the collection menu</param>
        /// <param name="giftName">Name of the gift - Displayed on the collection menu</param>
        /// <param name="canBeBought">Whether or not the gift can be obtained from the Monomono Machine</param>
        /// <param name="description">Description of the gift - Displayed on the collection menu</param>
        /// <param name="reactionsToGift">Dictionary of reactions to provoke to each character. int = Character ID, GiftReaction = Reaction</param>
        public Gift(int giftID, string giftName, bool canBeBought, string description, Dictionary<int, GiftReaction> reactionsToGift)
        {
            id = giftID;
            name = giftName;
            isRollable = canBeBought;
            descript = description;
            characterReactions = reactionsToGift;
            giftable = true;
        }

        public enum GiftReaction
        {
            Ungiftable,
            Hate,
            Dislike,
            Neutral,
            Like,
            Love
        }

        public GiftReaction GetReaction(Character recipient)
        {
            if (!giftable) { return GiftReaction.Ungiftable; }
            if (characterReactions != null) { foreach(int i in characterReactions.Keys) if (Global.GetCharFromID(i) == recipient) { return characterReactions[i]; } }
            return GiftReaction.Neutral;
        }
    }
}
