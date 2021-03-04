using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Fractured.World
{
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
        public const int Gift_ID_Chapter0 = 1;
        public const int Gift_ID_Chapter1 = 2;
        public const int Gift_ID_Chapter2 = 3;
        public const int Gift_ID_Chapter3 = 4;
        public const int Gift_ID_Chapter4 = 5;
        public const int Gift_ID_Chapter5 = 6;
        public const int Gift_ID_Chapter6 = 7;
        public const int Gift_ID_Chapter7 = 8;
        public const int Gift_ID_UnderDaichi = 9;
        public const int Gift_ID_UnderAyumu = 10;
        public const int Gift_ID_UnderYori = 11;
        public const int Gift_ID_UnderAkihito = 12;
        public const int Gift_ID_UnderTomomi = 13;
        public const int Gift_ID_UnderKatsuo = 14;
        public const int Gift_ID_UnderKeshi = 15;
        public const int Gift_ID_UnderMayu = 16;
        public const int Gift_ID_UnderKaren = 17;
        public const int Gift_ID_UnderScarlet = 18;
        public const int Gift_ID_UnderMichiko = 19;
        public const int Gift_ID_UnderMina = 20;
        public const int Gift_ID_UnderHoshi = 21;
        public const int Gift_ID_UnderAiri = 22;
        public const int Gift_ID_UnderShun = 23;
        public const int Gift_ID_UnderRin = 24;
        public const int Gift_ID_BottleWater = 25;
        public const int Gift_ID_SurvivalGuide = 26;
        public const int Gift_ID_SleepingMat = 27;
        public const int Gift_ID_CanMeal = 28;
        public const int Gift_ID_RosePerfume = 29;
        public const int Gift_ID_RoyalTea = 30;
        public const int Gift_ID_NovelK = 31;
        public const int Gift_ID_Swop = 32;
        public const int Gift_ID_SchoolRing = 33;
        public const int Gift_ID_ManPromise = 34;
        public const int Gift_ID_MuiscalCuff = 35;
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
        public const int Loc_ID_Trial1 = 14;
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
            Gifts.Add(new Gift(Gift_ID_Chapter0, 0, "Bomb Fragment", false, null, null, null, null, "Proof that you've cleared the Prologue. A piece of the bomb that started it all."));
            Gifts.Add(new Gift(Gift_ID_UnderDaichi, 0, "Daichi's Undergarments", false, null, null, null, null, ""));
            Gifts.Add(new Gift(Gift_ID_UnderAyumu, 0, "Ayumu's Undergarments", false, null, null, null, null, "Ayumu's favorite boxers. Loose fitting and breathable for maximum comfort, even for an athlete. He even signed them for you."));
            Gifts.Add(new Gift(Gift_ID_UnderYori, 0, "Yori's Undergarments", false, null, null, null, null, "Yori's favorite briefs. They're tight fitting so bugs don't crawl into them."));
            Gifts.Add(new Gift(Gift_ID_UnderAkihito, 0, "Akihito's Undergarments", false, null, null, null, null, "Akihito's favorite briefs. The pattern helps hide stains."));
            Gifts.Add(new Gift(Gift_ID_UnderTomomi, 0, "Tomomi's Undergarments", false, null, null, null, null, "Tomomi's handmade boxers. All his underwear is custom made by himself. He apparently made this pair specifically for you."));
            Gifts.Add(new Gift(Gift_ID_UnderKatsuo, 0, "Katsuo's Undergarments", false, null, null, null, null, "Katsuo's favorite boxers. The manliest type of underwear. Only for manly men."));
            Gifts.Add(new Gift(Gift_ID_UnderKeshi, 0, "Takeshi's Undergarments", false, null, null, null, null, "Keshi's only pair of worn out boxers. You gave him a fresh pair in exchange."));
            Gifts.Add(new Gift(Gift_ID_UnderMayu, 0, "Mayu's Undergarments", false, null, null, null, null, "Mayu's favorite panties. At first glance they look to be made of very expensive material, however further inspection shows it's cheap synthetic."));
            Gifts.Add(new Gift(Gift_ID_UnderKaren, 0, "Karen's Undergarments", false, null, null, null, null, "Karen's favorite cutesy panties. Despite the cute cat design on them, they're actually very versatile and durable."));
            Gifts.Add(new Gift(Gift_ID_UnderScarlet, 0, "Hotaru's Undergarments", false, new Character[] { GetCharFromID(Char_ID_Scarlet) }, null, null, null, "Scarlet's panties. Apparently she loses her underwear very often, so she buys plain panties in bulk. She would probably appreciate it if they're returned."));
            Gifts.Add(new Gift(Gift_ID_UnderMichiko, 0, "Michiko's Undergarments", false, null, null, null, null, "Michiko's favorite fashionable panties. She bought these while shopping with her best friend. Whenever she's lonely, she wears them as a reminder of their time together."));
            Gifts.Add(new Gift(Gift_ID_UnderMina, 0, "Kei's Undergarments", false, null, null, null, null, "Mina's favorite bearskin underwear. She hand crafted them from the skin of a bear she had killed. They aren't all that comfortable."));
            Gifts.Add(new Gift(Gift_ID_UnderHoshi, 0, "Hoshi's Undergarments", false, null, null, null, null, "Hoshi's favorite panties. The star pattern on them show the future for whoever is lucky enough to see them."));
            Gifts.Add(new Gift(Gift_ID_UnderAiri, 0, "Airi's Undergarments", false, null, null, null, null, "Airi's favorite panties. Although they're not the normal hacker attire, they are very comfortable to wear. This is the only type she wears."));
            Gifts.Add(new Gift(Gift_ID_UnderShun, 0, "Shun's Undergarments", false, null, null, null, null, "Shun's favorite panties."));
            Gifts.Add(new Gift(Gift_ID_UnderRin, 0, "Rin's Undergarments", false, null, null, null, null, "Rin's favorite pair of underwear. The musical pattern on them don't actually mean anything, and would sound terrible if played."));
            Gifts.Add(new Gift(Gift_ID_BottleWater, 1, "Bottled Rain Water", true, new Character[] { GetCharFromID(Char_ID_Daichi), GetCharFromID(Char_ID_Mayu) }, new Character[] { GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Yori), GetCharFromID(Char_ID_Hoshi) }, new Character[] { GetCharFromID(Char_ID_Keshi) }, null, "Rain water that has been collected and purified for drinking. It costs 5 times as much as normal bottled water, however the taste is indestinguishable."));
            Gifts.Add(new Gift(Gift_ID_SurvivalGuide, 0, "Survival Guide", true, new Character[] { GetCharFromID(Char_ID_Daichi) }, new Character[] { GetCharFromID(Char_ID_Shun) }, null, new Character[] { GetCharFromID(Char_ID_Keshi) }, "Everything you need to know about surviving in the wild, from how to build a fire, to how to hunt for food. The favorite of a certain soldier."));
            Gifts.Add(new Gift(Gift_ID_SleepingMat, 0, "Portable Sleeping Mat", true, new Character[] { GetCharFromID(Char_ID_Daichi) }, new Character[] { GetCharFromID(Char_ID_Scarlet) }, new Character[] { GetCharFromID(Char_ID_Mayu) }, null, "A cheap sleeping mat that can be rolled up and brought with you. Perfect for when you don't have time to find a bed to sleep on."));
            Gifts.Add(new Gift(Gift_ID_CanMeal, 3, "Meal in a Can", true, new Character[] { GetCharFromID(Char_ID_Daichi) }, new Character[] { GetCharFromID(Char_ID_Mina), GetCharFromID(Char_ID_Keshi) }, null, null, "A small meal inside a metal can that can be warmed up directly on a fire or stove. It is very nutritious, however it doesn't taste good."));
            Gifts.Add(new Gift(Gift_ID_RosePerfume, 0, "Rose Perfume", true, new Character[] { GetCharFromID(Char_ID_Mayu), GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Michiko), GetCharFromID(Char_ID_Hoshi) }, new Character[] { GetCharFromID(Char_ID_Daichi), GetCharFromID(Char_ID_Yori), GetCharFromID(Char_ID_Shun) }, new Character[] { GetCharFromID(Char_ID_Akihito), GetCharFromID(Char_ID_Airi) }, new Character[] { GetCharFromID(Char_ID_Katsuo) }, "A perfume made from rose petals. It doesn't have a very strong scent in order to simulate the scent of nature coming in from a second story window."));
            Gifts.Add(new Gift(Gift_ID_RoyalTea, 2, "Royal Milk Tea", true, new Character[] { GetCharFromID(Char_ID_Karen) }, new Character[] { GetCharFromID(Char_ID_Michiko), GetCharFromID(Char_ID_Akihito), GetCharFromID(Char_ID_Tomomi) }, null, new Character[] { GetCharFromID(Char_ID_Mayu) }, "Tea with milk in it. The milk is blended into the tea during the brewing process to perfect the flavor. Drinking it is said to help those who need to stay calm during a gamble"));
            Gifts.Add(new Gift(Gift_ID_NovelK, 0, "Mystery Novel K", true, new Character[] { GetCharFromID(Char_ID_Michiko) }, new Character[] { GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Akihito), GetCharFromID(Char_ID_Airi) }, new Character[] { GetCharFromID(Char_ID_Hoshi) }, new Character[] { GetCharFromID(Char_ID_Keshi) }, "A novel about an Ultimate Detective and her older sister solving a murder at an observatory. The first book in a series that you should buy all of"));
            Gifts.Add(new Gift(Gift_ID_Swop, 0, "The Swop", true, new Character[] { GetCharFromID(Char_ID_Airi) }, new Character[] { GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Ayumu), GetCharFromID(Char_ID_Scarlet), GetCharFromID(Char_ID_Akihito) }, new Character[] { GetCharFromID(Char_ID_Daichi), GetCharFromID(Char_ID_Keshi) }, null, "A video game console that can be played on a television or on the go. It is rumored you can play every game ever made on it."));
            Gifts.Add(new Gift(Gift_ID_SchoolRing, 0, "Rusted School Ring", true, null, new Character[] { GetCharFromID(Char_ID_Daichi), GetCharFromID(Char_ID_Mayu), GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Ayumu), GetCharFromID(Char_ID_Yori), GetCharFromID(Char_ID_Scarlet), GetCharFromID(Char_ID_Michiko), GetCharFromID(Char_ID_Akihito), GetCharFromID(Char_ID_Tomomi), GetCharFromID(Char_ID_Mina), GetCharFromID(Char_ID_Hoshi), GetCharFromID(Char_ID_Katsuo), GetCharFromID(Char_ID_Airi), GetCharFromID(Char_ID_Shun), GetCharFromID(Char_ID_Keshi), GetCharFromID(Char_ID_Noboku) }, null, null, "An old ring that you can barely make out a school crest on. You can feel those who wore it had a strong bond of friendship between them."));
            Gifts.Add(new Gift(Gift_ID_ManPromise, 0, "A Man's Promise", true, null, null, null, null, "A note promising to fulfill a man's fantasy. Something interesting may happen if I keep it with me"));
            Gifts.Add(new Gift(Gift_ID_MuiscalCuff, 0, "Musical Cufflink", false, null, null, null, null, "A cufflink in the shape of a musical note. A gift from Shun that she found after the explosion. Although I've never seen it before, it has my initials engraved in the back."));
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
            Locations.Add(new Location(Loc_ID_Trial1, "Trial1", "", 1, Location.LocationType.Trial_Room));
            Locations.Add(new Location(Loc_ID_Lake, "Lake", "Lake Despair", 9, Location.LocationType.Moveable_Room));
            Locations.Add(new Location(Loc_ID_Hike1, "Hike1", "Lower Trail", 9, Location.LocationType.Moveable_Room));
        }

        private static void PopulateStory()
        {
            StoryMarkers.Add(new StoryMarker(0, 0, StoryMarker.Time.Morning, StoryMarker.Mode.Story, "I should finish meeting my classmates before heading into the camp...", GetLocFromID(Loc_ID_Entrance), null, null, new Character[] { GetCharFromID(Char_ID_Karen), GetCharFromID(Char_ID_Mayu), GetCharFromID(Char_ID_Ayumu), GetCharFromID(Char_ID_Yori)}, null));
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