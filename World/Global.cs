using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Fractured.World
{
    /*WARNING: This file contains data that may be considered spoilers including:
     * 
     * Character Gift Preferences
     * Names of locations not yet visitable in available chapters
     * Description of certain gifts and story markers may reference story events
     * 
     * 
     * Proceed at your own risk*/


    public class Global
    {
        public static readonly List<Character> Characters = new List<Character>();
        public static readonly List<Gift> Gifts = new List<Gift>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<StoryMarker> StoryMarkers = new List<StoryMarker>();

        #region Character ID
        public const int Char_ID_Null = 0;
        public const int Char_ID_Rin = 1;
        public const int Char_ID_Daichi = 2;
        public const int Char_ID_Mayu = 3;
        public const int Char_ID_Karen = 4;
        public const int Char_ID_Ayumu = 5;
        public const int Char_ID_Yori = 6;
        public const int Char_ID_Scarlet = 7;
        public const int Char_ID_Michiko = 8;
        public const int Char_ID_Akihito = 9;
        public const int Char_ID_Tomomi = 10;
        public const int Char_ID_Mina = 11;
        public const int Char_ID_Hoshi = 12;
        public const int Char_ID_Katsuo = 13;
        public const int Char_ID_Airi = 14;
        public const int Char_ID_Shun = 15;
        public const int Char_ID_Keshi = 16;
        public const int Char_ID_Yuki = 17;
        public const int Char_ID_Noboku = 18;
        public const int Char_ID_Kaishi = 19;
        public const int Char_ID_Monokuma = 20;
        public const int Char_ID_Mastermind = 21;
        public const int Char_ID_Despair = 22;
        public const int Char_ID_Grey = 23;
        public const int Char_ID_Thoughts = 24;
        public const int Char_ID_Tutorial = 25;
        #endregion

        #region Gift ID
        public const int Gift_ID_BottleWater = 1;
        public const int Gift_ID_SurvivalGuide = 2;
        public const int Gift_ID_SleepingMat = 3;
        public const int Gift_ID_CanMeal = 4;
        public const int Gift_ID_RosePerfume = 5;
        public const int Gift_ID_RoyalTea = 6;
        public const int Gift_ID_NovelK = 7;
        public const int Gift_ID_Swop = 8;
        public const int Gift_ID_SchoolRing = 9;
        public const int Gift_ID_ManPromise = 10;
        public const int Gift_ID_MuiscalCuff = 11;
        public const int Gift_ID_UnderDaichi = 76;
        public const int Gift_ID_UnderAyumu = 77;
        public const int Gift_ID_UnderYori = 78;
        public const int Gift_ID_UnderAkihito = 79;
        public const int Gift_ID_UnderTomomi = 80;
        public const int Gift_ID_UnderKatsuo = 81;
        public const int Gift_ID_UnderKeshi = 82;
        public const int Gift_ID_UnderMayu = 83;
        public const int Gift_ID_UnderKaren = 84;
        public const int Gift_ID_UnderScarlet = 85;
        public const int Gift_ID_UnderMichiko = 86;
        public const int Gift_ID_UnderMina = 87;
        public const int Gift_ID_UnderHoshi = 88;
        public const int Gift_ID_UnderAiri = 89;
        public const int Gift_ID_UnderShun = 90;
        public const int Gift_ID_UnderRin = 91;
        public const int Gift_ID_Chapter0 = 92;
        public const int Gift_ID_Chapter1 = 93;
        public const int Gift_ID_Chapter2 = 94;
        public const int Gift_ID_Chapter3 = 95;
        public const int Gift_ID_Chapter4 = 96;
        public const int Gift_ID_Chapter5 = 97;
        public const int Gift_ID_Chapter6 = 98;
        public const int Gift_ID_Chapter7 = 99;
        #endregion

        #region Location ID
        public const int Loc_ID_Null = 0;
        public const int Loc_ID_Entrance = 1;
        public const int Loc_ID_Camp1 = 2;
        public const int Loc_ID_Kaboom = 3;
        public const int Loc_ID_Lounge1 = 4;
        public const int Loc_ID_Camp2 = 5;
        public const int Loc_ID_Bed = 6;
        public const int Loc_ID_Cafe = 7;
        public const int Loc_ID_Shower = 8;
        public const int Loc_ID_Campfire = 9;
        public const int Loc_ID_Laundry = 10;
        public const int Loc_ID_Health = 11;
        public const int Loc_ID_Store = 12;
        public const int Loc_ID_Junk = 13;
        public const int Loc_ID_Trial = 14;
        public const int Loc_ID_Lake = 15;
        public const int Loc_ID_Hike1 = 16;
        #endregion

        static Global()
        {
            PopulateChar();
            PopulateGifts();
            PopulateLoc();
            PopulateStory();
        }

        #region Populate Classes
        private static void PopulateChar()
        {
            Characters.Add(new Character(Char_ID_Null, "", "", 0));
            Characters.Add(new Character(Char_ID_Rin, "Rin", "Rin Katou", 1.6));
            Characters.Add(new Character(Char_ID_Daichi, "Daichi", "Daichi Kobayashi", 1.76));
            Characters.Add(new Character(Char_ID_Mayu, "Mayu", "Mayu Nakajima", 1.75));
            Characters.Add(new Character(Char_ID_Karen, "Karen", "Karen Akiyama", 1.58));
            Characters.Add(new Character(Char_ID_Ayumu, "Ayumu", "Ayumu Sanada", 1.76));
            Characters.Add(new Character(Char_ID_Yori, "Yori", "Yori Arima", 1.6));
            Characters.Add(new Character(Char_ID_Scarlet, "Scarlet", "Hotaru Himura", 1.58));
            Characters.Add(new Character(Char_ID_Michiko, "Michiko", "Michiko Okuso", 1.6));
            Characters.Add(new Character(Char_ID_Akihito, "Akihito", "Akihito Tsukada", 1.55));
            Characters.Add(new Character(Char_ID_Tomomi, "Tomomi", "Tomomi Sakaji", 1.7));
            Characters.Add(new Character(Char_ID_Mina, "Mina", "Kei Minami", 1.85));
            Characters.Add(new Character(Char_ID_Hoshi, "Hoshi", "Hoshi Ikeda", 1.6));
            Characters.Add(new Character(Char_ID_Katsuo, "Katsuo", "Katsuo Sato", 1.68));
            Characters.Add(new Character(Char_ID_Airi, "Airi", "Airi Honda", 1.74));
            Characters.Add(new Character(Char_ID_Shun, "Shun", "Shun Tachibana", 1.76));
            Characters.Add(new Character(Char_ID_Keshi, "Keshi", "Takeshi Ishikawa", 1.75));
            Characters.Add(new Character(Char_ID_Yuki, "", "???", 1.74));
            Characters.Add(new Character(Char_ID_Noboku, "", "???", 1.73));
            Characters.Add(new Character(Char_ID_Kaishi, "", "???", 1.69));
            Characters.Add(new Character(Char_ID_Monokuma, "Monokuma", "Monokuma", 0.75));
            Characters.Add(new Character(Char_ID_Mastermind, "", "???", 0));
            Characters.Add(new Character(Char_ID_Despair, "", "???", 0));
            Characters.Add(new Character(Char_ID_Grey, "", "???", 0));
            Characters.Add(new Character(Char_ID_Thoughts, "", "", 0));
            Characters.Add(new Character(Char_ID_Tutorial, "", "", 0));

        }

        private static void PopulateGifts()
        {
            Gift.GiftReaction love = Gift.GiftReaction.Love;
            Gift.GiftReaction like = Gift.GiftReaction.Like;
            Gift.GiftReaction dislike = Gift.GiftReaction.Dislike;
            Gift.GiftReaction hate = Gift.GiftReaction.Hate;

            Gifts.Add(new Gift(Gift_ID_BottleWater, "Bottled Rain Water", true, "Rain water that has been collected and purified for drinking. It costs 5 times as much as normal bottled water, however the taste is indestinguishable.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Daichi, love }, { Char_ID_Mayu, love }, { Char_ID_Karen, like }, { Char_ID_Yori, like }, { Char_ID_Hoshi, like }, { Char_ID_Keshi, dislike } }));
            Gifts.Add(new Gift(Gift_ID_SurvivalGuide, "Survival Guide", true, "Everything you need to know about surviving in the wild, from how to build a fire, to how to hunt for food. The favorite of a certain soldier.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Daichi, love }, { Char_ID_Shun, like }, { Char_ID_Keshi, hate } }));
            Gifts.Add(new Gift(Gift_ID_SleepingMat, "Portable Sleeping Mat", true, "A cheap sleeping mat that can be rolled up and brought with you. Perfect for when you don't have time to find a bed to sleep on.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Daichi, love }, { Char_ID_Scarlet, like }, { Char_ID_Mayu, dislike } }));
            Gifts.Add(new Gift(Gift_ID_CanMeal, "Meal in a Can", true, "A small meal inside a metal can that can be warmed up directly on a fire or stove. It is very nutritious, however it doesn't taste good.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Daichi, love }, { Char_ID_Mina, like }, { Char_ID_Keshi, like } }));
            Gifts.Add(new Gift(Gift_ID_RosePerfume, "Rose Perfume", true, "A perfume made from rose petals. It doesn't have a very strong scent in order to simulate the scent of nature coming in from a second story window.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Mayu, love }, { Char_ID_Karen, love }, { Char_ID_Michiko, love }, { Char_ID_Hoshi, love }, { Char_ID_Daichi, like }, { Char_ID_Yori, like }, { Char_ID_Shun, like }, { Char_ID_Akihito, dislike }, { Char_ID_Airi, dislike }, { Char_ID_Katsuo, hate } }));
            Gifts.Add(new Gift(Gift_ID_RoyalTea, "Royal Milk Tea", true, "Tea with milk in it. The milk is blended into the tea during the brewing process to perfect the flavor. Drinking it is said to help those who need to stay calm during a gamble", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Karen, love }, { Char_ID_Michiko, like }, { Char_ID_Akihito, like }, { Char_ID_Tomomi, like }, { Char_ID_Mayu, hate } }));
            Gifts.Add(new Gift(Gift_ID_NovelK, "Mystery Novel K", true, "A novel about an Ultimate Detective and her older sister solving a murder at an observatory. The first book in a series that you should buy all of", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Michiko, love }, { Char_ID_Karen, like }, { Char_ID_Akihito, like }, { Char_ID_Airi, like }, { Char_ID_Hoshi, dislike }, { Char_ID_Keshi, hate } }));
            Gifts.Add(new Gift(Gift_ID_Swop, "The Swop", true, "A video game console that can be played on a television or on the go. It is rumored you can play every game ever made on it.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Airi, love }, { Char_ID_Karen, like }, { Char_ID_Ayumu, like }, { Char_ID_Scarlet, like }, { Char_ID_Akihito, like }, { Char_ID_Daichi, dislike }, { Char_ID_Keshi, dislike } }));
            Gifts.Add(new Gift(Gift_ID_SchoolRing, "Rusted School Ring", true, "An old ring that you can barely make out a school crest on. You can feel those who wore it had a strong bond of friendship between them.", like));

            Gifts.Add(new Gift(Gift_ID_ManPromise, "A Man's Promise", true, "A note promising to fulfill a man's fantasy. Something interesting may happen if I keep it with me"));
            Gifts.Add(new Gift(Gift_ID_MuiscalCuff, "Musical Cufflink", false, "A cufflink in the shape of a musical note. A gift from Shun that she found after the explosion. Although I've never seen it before, it has my initials engraved in the back."));

            Gifts.Add(new Gift(Gift_ID_UnderDaichi, "Daichi's Undergarments", false, ""));
            Gifts.Add(new Gift(Gift_ID_UnderAyumu, "Ayumu's Undergarments", false, "Ayumu's favorite boxers. Loose fitting and breathable for maximum comfort, even for an athlete. He even signed them for you."));
            Gifts.Add(new Gift(Gift_ID_UnderYori, "Yori's Undergarments", false, "Yori's favorite briefs. They're tight fitting so bugs don't crawl into them."));
            Gifts.Add(new Gift(Gift_ID_UnderAkihito, "Akihito's Undergarments", false, "Akihito's favorite briefs. The pattern helps hide stains."));
            Gifts.Add(new Gift(Gift_ID_UnderTomomi, "Tomomi's Undergarments", false, "Tomomi's handmade boxers. All his underwear is custom made by himself. He apparently made this pair specifically for you."));
            Gifts.Add(new Gift(Gift_ID_UnderKatsuo, "Katsuo's Undergarments", false, "Katsuo's favorite boxers. The manliest type of underwear. Only for manly men."));
            Gifts.Add(new Gift(Gift_ID_UnderKeshi, "Takeshi's Undergarments", false, "Keshi's only pair of worn out boxers. You gave him a fresh pair in exchange."));
            Gifts.Add(new Gift(Gift_ID_UnderMayu, "Mayu's Undergarments", false, "Mayu's favorite panties. At first glance they look to be made of very expensive material, however further inspection shows it's cheap synthetic."));
            Gifts.Add(new Gift(Gift_ID_UnderKaren, "Karen's Undergarments", false, "Karen's favorite cutesy panties. Despite the cute cat design on them, they're actually very versatile and durable."));
            Gifts.Add(new Gift(Gift_ID_UnderScarlet, "Hotaru's Undergarments", false, "Scarlet's panties. Apparently she loses her underwear very often, so she buys plain panties in bulk. She would probably appreciate it if they're returned.", new Dictionary<int, Gift.GiftReaction>() { { Char_ID_Scarlet, Gift.GiftReaction.Love } }));
            Gifts.Add(new Gift(Gift_ID_UnderMichiko, "Michiko's Undergarments", false, "Michiko's favorite fashionable panties. She bought these while shopping with her best friend. Whenever she's lonely, she wears them as a reminder of their time together."));
            Gifts.Add(new Gift(Gift_ID_UnderMina, "Kei's Undergarments", false, "Mina's favorite bearskin underwear. She hand crafted them from the skin of a bear she had killed. They aren't all that comfortable."));
            Gifts.Add(new Gift(Gift_ID_UnderHoshi, "Hoshi's Undergarments", false, "Hoshi's favorite panties. The star pattern on them show the future for whoever is lucky enough to see them."));
            Gifts.Add(new Gift(Gift_ID_UnderAiri, "Airi's Undergarments", false, "Airi's favorite panties. Although they're not the normal hacker attire, they are very comfortable to wear. This is the only type she wears."));
            Gifts.Add(new Gift(Gift_ID_UnderShun, "Shun's Undergarments", false, "Shun's favorite panties."));
            Gifts.Add(new Gift(Gift_ID_UnderRin, "Rin's Undergarments", false, "Rin's favorite pair of underwear. The musical pattern on them don't actually mean anything, and would sound terrible if played."));
            Gifts.Add(new Gift(Gift_ID_Chapter0, "Bomb Fragment", false, "Proof that you've cleared the Prologue. A piece of the bomb that started it all."));
        }

        private static void PopulateLoc()
        {
            Locations.Add(new Location(Loc_ID_Null, "", "", 0, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Entrance, "Entrance", "Camp Entrance", 0, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Camp1, "Camp1", "Main Camp Yard", 0, Location.LocationType.Moveable_Room));
            Locations.Add(new Location(Loc_ID_Kaboom, "Kaboom", "Camp Entrance", 0, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Lounge1, "Lounge1", "Lobby", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Camp2, "Camp2", "Residential Yard", 1, Location.LocationType.Moveable_Room));
            Locations.Add(new Location(Loc_ID_Bed, "Bed", "Dorms", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Cafe, "Cafe", "Cafeteria", 0, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Shower, "Shower", "Showers", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Campfire, "Campfire", "Campfire", 0, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Laundry, "Laundry", "Laundry Room", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Health, "Health", "Health Office", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Store, "Store", "School Store", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Junk, "Junk", "Junkyard", 1, Location.LocationType.Static_Room));
            Locations.Add(new Location(Loc_ID_Trial, "Trial", "", 1, Location.LocationType.Trial_Room));
            Locations.Add(new Location(Loc_ID_Lake, "Lake", "Lake Despair", 9, Location.LocationType.Moveable_Room));
            Locations.Add(new Location(Loc_ID_Hike1, "Hike1", "Lower Trail", 9, Location.LocationType.Moveable_Room));
        }

        private static void PopulateStory()
        {
            StoryMarkers.Add(new StoryMarker(0, 0, StoryMarker.Time.Morning, StoryMarker.Mode.Story, "I should finish meeting my classmates before heading into the camp...", GetLocFromID(Loc_ID_Null), null, null, new Character[] { GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Mayu), GetCharFromID(Char_ID_Ayumu), GetCharFromID(Char_ID_Yori)}, null));
            StoryMarkers.Add(new StoryMarker(1, 0, StoryMarker.Time.Morning, StoryMarker.Mode.Story, "More classmates showed up, I should introduce myself before heading into camp...", GetLocFromID(Loc_ID_Entrance), null, null, new Character[] { GetCharFromID(Char_ID_Akihito), GetCharFromID(Char_ID_Michiko), GetCharFromID(Char_ID_Scarlet), GetCharFromID(Char_ID_Tomomi), GetCharFromID(Char_ID_Mina)}, null));
            StoryMarkers.Add(new StoryMarker(2, 0, StoryMarker.Time.Morning, StoryMarker.Mode.Story, "I should leave Tomomi to calming Mayu. In the meantime, I should finish introductions...", GetLocFromID(Loc_ID_Entrance), null, null, new Character[] { GetCharFromID(Char_ID_Hoshi), GetCharFromID(Char_ID_Katsuo), GetCharFromID(Char_ID_Airi), GetCharFromID(Char_ID_Shun)}, null));
            StoryMarkers.Add(new StoryMarker(3, 0, StoryMarker.Time.Morning, StoryMarker.Mode.Story, "I should make sure everyone's okay before leaving...", GetLocFromID(Loc_ID_Entrance), null, null, new Character[] { GetCharFromID(Char_ID_Michiko), GetCharFromID(Char_ID_Tomomi), GetCharFromID(Char_ID_Mina), GetCharFromID(Char_ID_Keshi)}, null));
            StoryMarkers.Add(new StoryMarker(4, 0, StoryMarker.Time.Day, StoryMarker.Mode.Story, "I need to head to the campfire so I don't get in trouble...", GetLocFromID(Loc_ID_Cafe), new Location[] { GetLocFromID(Loc_ID_Camp1), GetLocFromID(Loc_ID_Campfire) }, null, null, null));
            //StoryMarkers.Add(new StoryMarker(5, 1, 2, 0, "", GetLocFromID(Loc_ID_Campfire), null, null, null, null));
        }
        #endregion

        #region Get ID Methods
        public static Character GetCharFromID(int ID)
        {
            foreach (Character i in Characters)
                if (i.ID == ID)
                    return i;

            return null;
        }

        public static Gift GetGiftFromID(int ID)
        {
            foreach (Gift i in Gifts)
                if (i.ID == ID)
                    return i;

            return null;
        }

        public static Location GetLocFromID(int ID)
        {
            foreach (Location i in Locations)
                if (i.ID == ID)
                    return i;

            return null;
        }

        public static StoryMarker GetMarkerFromID(int ID)
        {
            foreach (StoryMarker m in StoryMarkers) { if (m.ID == ID) return m; }
            return null;
        }
        #endregion

        public static Rectangle RectangleFromCharacterSpriteID(int index)
        {
            int sheetWidth = 4;
            return new Rectangle(index % sheetWidth * 1000, (int)MathF.Floor(index / sheetWidth) * 2500, 1000, 2500);
        }
    }
}