namespace spotivy_app.spotivy
{
    public class Constants
    {
        public enum Genre
        {
            Pop = 0, Rock = 1, HipHop = 2, Rap = 3, RnB = 4, Jazz = 5,
            Blues = 6, Classical = 7, Country = 8, Electronic = 9, Dance = 10,
            House = 11, Techno = 12, Trance = 13, Dubstep = 14, DrumAndBass = 15,
            Reggae = 16, Ska = 17, Metal = 18, Punk = 19, Alternative = 20,
            Indie = 21, Folk = 22, Soul = 23, Funk = 24, Disco = 25,
            Gospel = 26, Opera = 27, Latin = 28, Salsa = 29, Reggaeton = 30,
            KPop = 31, JPop = 32, World = 33, Ambient = 34, Chillout = 35,
            Soundtrack = 36, Musical = 37, Children = 38, Comedy = 39, SpokenWord = 40,
            Experimental = 41, NewAge = 42, Grunge = 43, LoFi = 44, Synthpop = 45,
            Industrial = 46, Emo = 47, Bluegrass = 48, Afrobeat = 49, Trap = 50
        }

        public List<List<Album>> albumLists = new List<List<Album>>
        {
            new List<Album>{
               new Album(new List<Artist>(), "Abbey Road", new List<Song>
               {
                   new Song("Come Together", new List<Artist>(), Genre.Rock, 259),
                   new Song("Something", new List<Artist>(), Genre.Rock, 182),
                   new Song("Maxwell's Silver Hammer", new List<Artist>(), Genre.Rock, 207),
                   new Song("Oh! Darling", new List<Artist>(), Genre.Rock, 207),
                   new Song("Octopus's Garden", new List<Artist>(), Genre.Rock, 175)
               }),
               new Album(new List<Artist>(), "Sgt. Pepper's Lonely Hearts Club Band", new List<Song>
               {
                   new Song("Sgt. Pepper's Lonely Hearts Club Band", new List<Artist>(), Genre.Rock, 122),
                   new Song("With a Little Help from My Friends", new List<Artist>(), Genre.Rock, 164),
                   new Song("Lucy in the Sky with Diamonds", new List<Artist>(), Genre.Rock, 208),
                   new Song("Getting Better", new List<Artist>(), Genre.Rock, 168),
                   new Song("Fixing a Hole", new List<Artist>(), Genre.Rock, 152)
               }),
               new Album(new List<Artist>(), "Revolver", new List<Song>
               {
                   new Song("Taxman", new List<Artist>(), Genre.Rock, 157),
                   new Song("Eleanor Rigby", new List<Artist>(), Genre.Rock, 138),
                   new Song("I'm Only Sleeping", new List<Artist>(), Genre.Rock, 183),
                   new Song("Love You To", new List<Artist>(), Genre.Rock, 181),
                   new Song("Here, There and Everywhere", new List<Artist>(), Genre.Rock, 149)
               }),
               new Album(new List<Artist>(), "Rubber Soul", new List<Song>
               {
                   new Song("Drive My Car", new List<Artist>(), Genre.Rock, 146),
                   new Song("Norwegian Wood (This Bird Has Flown)", new List<Artist>(), Genre.Rock, 121),
                   new Song("You Won't See Me", new List<Artist>(), Genre.Rock, 199),
                   new Song("Nowhere Man", new List<Artist>(), Genre.Rock, 163),
                   new Song("Think for Yourself", new List<Artist>(), Genre.Rock, 138)
               })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "1989", new List<Song>
                {
                    new Song("Welcome To New York", new List<Artist>(), Genre.Pop, 212),
                    new Song("Blank Space", new List<Artist>(), Genre.Pop, 231),
                    new Song("Style", new List<Artist>(), Genre.Pop, 231),
                    new Song("Out of the Woods", new List<Artist>(), Genre.Pop, 235),
                    new Song("All You Had To Do Was Stay", new List<Artist>(), Genre.Pop, 193)
                }),
                new Album(new List<Artist>(), "Red", new List<Song>
                {
                    new Song("State of Grace", new List<Artist>(), Genre.Pop, 295),
                    new Song("Red", new List<Artist>(), Genre.Pop, 223),
                    new Song("Treacherous", new List<Artist>(), Genre.Pop, 241),
                    new Song("I Knew You Were Trouble", new List<Artist>(), Genre.Pop, 220),
                    new Song("All Too Well", new List<Artist>(), Genre.Pop, 329)
                }),
                new Album(new List<Artist>(), "Lover", new List<Song>
                {
                    new Song("I Forgot That You Existed", new List<Artist>(), Genre.Pop, 161),
                    new Song("Cruel Summer", new List<Artist>(), Genre.Pop, 178),
                    new Song("Lover", new List<Artist>(), Genre.Pop, 221),
                    new Song("The Man", new List<Artist>(), Genre.Pop, 190),
                    new Song("The Archer", new List<Artist>(), Genre.Pop, 211)
                }),
                new Album(new List<Artist>(), "Folklore", new List<Song>
                {
                    new Song("the 1", new List<Artist>(), Genre.Indie, 211),
                    new Song("cardigan", new List<Artist>(), Genre.Indie, 239),
                    new Song("the last great american dynasty", new List<Artist>(), Genre.Indie, 230),
                    new Song("exile", new List<Artist>(), Genre.Indie, 275),
                    new Song("my tears ricochet", new List<Artist>(), Genre.Indie, 255)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "A Night at the Opera", new List<Song>
                {
                    new Song("Death on Two Legs", new List<Artist>(), Genre.Rock, 217),
                    new Song("Lazing on a Sunday Afternoon", new List<Artist>(), Genre.Rock, 70),
                    new Song("I'm in Love with My Car", new List<Artist>(), Genre.Rock, 191),
                    new Song("You're My Best Friend", new List<Artist>(), Genre.Rock, 169),
                    new Song("'39", new List<Artist>(), Genre.Rock, 189)
                }),
                new Album(new List<Artist>(), "News of the World", new List<Song>
                {
                    new Song("We Will Rock You", new List<Artist>(), Genre.Rock, 122),
                    new Song("We Are the Champions", new List<Artist>(), Genre.Rock, 179),
                    new Song("Sheer Heart Attack", new List<Artist>(), Genre.Rock, 188),
                    new Song("All Dead, All Dead", new List<Artist>(), Genre.Rock, 187),
                    new Song("Spread Your Wings", new List<Artist>(), Genre.Rock, 244)
                }),
                new Album(new List<Artist>(), "The Game", new List<Song>
                {
                    new Song("Play the Game", new List<Artist>(), Genre.Rock, 217),
                    new Song("Dragon Attack", new List<Artist>(), Genre.Rock, 244),
                    new Song("Another One Bites the Dust", new List<Artist>(), Genre.Rock, 215),
                    new Song("Need Your Loving Tonight", new List<Artist>(), Genre.Rock, 168),
                    new Song("Crazy Little Thing Called Love", new List<Artist>(), Genre.Rock, 163)
                }),
                new Album(new List<Artist>(), "Jazz", new List<Song>
                {
                    new Song("Mustapha", new List<Artist>(), Genre.Rock, 203),
                    new Song("Fat Bottomed Girls", new List<Artist>(), Genre.Rock, 257),
                    new Song("Jealousy", new List<Artist>(), Genre.Rock, 210),
                    new Song("Bicycle Race", new List<Artist>(), Genre.Rock, 183),
                    new Song("If You Can't Beat Them", new List<Artist>(), Genre.Rock, 255)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "21", new List<Song>
                {
                    new Song("Rolling in the Deep", new List<Artist>(), Genre.Soul, 228),
                    new Song("Rumour Has It", new List<Artist>(), Genre.Soul, 223),
                    new Song("Turning Tables", new List<Artist>(), Genre.Soul, 244),
                    new Song("Don't You Remember", new List<Artist>(), Genre.Soul, 244),
                    new Song("Set Fire to the Rain", new List<Artist>(), Genre.Soul, 242)
                }),
                new Album(new List<Artist>(), "25", new List<Song>
                {
                    new Song("Hello", new List<Artist>(), Genre.Soul, 295),
                    new Song("Send My Love (To Your New Lover)", new List<Artist>(), Genre.Pop, 223),
                    new Song("I Miss You", new List<Artist>(), Genre.Pop, 340),
                    new Song("When We Were Young", new List<Artist>(), Genre.Pop, 289),
                    new Song("Remedy", new List<Artist>(), Genre.Pop, 242)
                }),
                new Album(new List<Artist>(), "19", new List<Song>
                {
                    new Song("Daydreamer", new List<Artist>(), Genre.Soul, 223),
                    new Song("Best for Last", new List<Artist>(), Genre.Soul, 242),
                    new Song("Chasing Pavements", new List<Artist>(), Genre.Soul, 208),
                    new Song("Cold Shoulder", new List<Artist>(), Genre.Soul, 228),
                    new Song("Crazy for You", new List<Artist>(), Genre.Soul, 205)
                }),
                new Album(new List<Artist>(), "30", new List<Song>
                {
                    new Song("Strangers by Nature", new List<Artist>(), Genre.Soul, 180),
                    new Song("Easy On Me", new List<Artist>(), Genre.Soul, 224),
                    new Song("My Little Love", new List<Artist>(), Genre.Soul, 360),
                    new Song("Cry Your Heart Out", new List<Artist>(), Genre.Soul, 240),
                    new Song("Oh My God", new List<Artist>(), Genre.Soul, 210)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Lemonade", new List<Song>
                {
                    new Song("Pray You Catch Me", new List<Artist>(), Genre.RnB, 197),
                    new Song("Hold Up", new List<Artist>(), Genre.RnB, 225),
                    new Song("Don't Hurt Yourself", new List<Artist>(), Genre.RnB, 223),
                    new Song("Sorry", new List<Artist>(), Genre.RnB, 223),
                    new Song("6 Inch", new List<Artist>(), Genre.RnB, 246)
                }),
                new Album(new List<Artist>(), "Beyoncé", new List<Song>
                {
                    new Song("Pretty Hurts", new List<Artist>(), Genre.RnB, 273),
                    new Song("Haunted", new List<Artist>(), Genre.RnB, 361),
                    new Song("Drunk in Love", new List<Artist>(), Genre.RnB, 319),
                    new Song("Blow", new List<Artist>(), Genre.RnB, 330),
                    new Song("No Angel", new List<Artist>(), Genre.RnB, 224)
                }),
                new Album(new List<Artist>(), "4", new List<Song>
                {
                    new Song("1+1", new List<Artist>(), Genre.RnB, 267),
                    new Song("I Care", new List<Artist>(), Genre.RnB, 246),
                    new Song("I Miss You", new List<Artist>(), Genre.RnB, 211),
                    new Song("Best Thing I Never Had", new List<Artist>(), Genre.RnB, 249),
                    new Song("Party", new List<Artist>(), Genre.RnB, 246)
                }),
                new Album(new List<Artist>(), "I Am... Sasha Fierce", new List<Song>
                {
                    new Song("If I Were a Boy", new List<Artist>(), Genre.RnB, 249),
                    new Song("Halo", new List<Artist>(), Genre.RnB, 261),
                    new Song("Disappear", new List<Artist>(), Genre.RnB, 246),
                    new Song("Broken-Hearted Girl", new List<Artist>(), Genre.RnB, 261),
                    new Song("Ave Maria", new List<Artist>(), Genre.RnB, 228)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Parachutes", new List<Song>
                {
                    new Song("Don't Panic", new List<Artist>(), Genre.Rock, 137),
                    new Song("Shiver", new List<Artist>(), Genre.Rock, 299),
                    new Song("Spies", new List<Artist>(), Genre.Rock, 330),
                    new Song("Sparks", new List<Artist>(), Genre.Rock, 216),
                    new Song("Yellow", new List<Artist>(), Genre.Rock, 269)
                }),
                new Album(new List<Artist>(), "A Rush of Blood to the Head", new List<Song>
                {
                    new Song("Politik", new List<Artist>(), Genre.Rock, 330),
                    new Song("In My Place", new List<Artist>(), Genre.Rock, 229),
                    new Song("God Put a Smile upon Your Face", new List<Artist>(), Genre.Rock, 295),
                    new Song("The Scientist", new List<Artist>(), Genre.Rock, 309),
                    new Song("Clocks", new List<Artist>(), Genre.Rock, 307)
                }),
                new Album(new List<Artist>(), "X&Y", new List<Song>
                {
                    new Song("Square One", new List<Artist>(), Genre.Rock, 295),
                    new Song("What If", new List<Artist>(), Genre.Rock, 297),
                    new Song("White Shadows", new List<Artist>(), Genre.Rock, 295),
                    new Song("Fix You", new List<Artist>(), Genre.Rock, 294),
                    new Song("Talk", new List<Artist>(), Genre.Rock, 312)
                }),
                new Album(new List<Artist>(), "Viva la Vida or Death and All His Friends", new List<Song>
                {
                    new Song("Life in Technicolor", new List<Artist>(), Genre.Rock, 146),
                    new Song("Cemeteries of London", new List<Artist>(), Genre.Rock, 181),
                    new Song("Lost!", new List<Artist>(), Genre.Rock, 227),
                    new Song("42", new List<Artist>(), Genre.Rock, 232),
                    new Song("Lovers in Japan / Reign of Love", new List<Artist>(), Genre.Rock, 366)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "WHEN WE ALL FALL ASLEEP, WHERE DO WE GO?", new List<Song>
                {
                    new Song("!!!!!!!", new List<Artist>(), Genre.Pop, 14),
                    new Song("bad guy", new List<Artist>(), Genre.Pop, 194),
                    new Song("xanny", new List<Artist>(), Genre.Pop, 244),
                    new Song("you should see me in a crown", new List<Artist>(), Genre.Pop, 180),
                    new Song("all the good girls go to hell", new List<Artist>(), Genre.Pop, 163)
                }),
                new Album(new List<Artist>(), "Happier Than Ever", new List<Song>
                {
                    new Song("Getting Older", new List<Artist>(), Genre.Pop, 244),
                    new Song("I Didn't Change My Number", new List<Artist>(), Genre.Pop, 152),
                    new Song("Billie Bossa Nova", new List<Artist>(), Genre.Pop, 178),
                    new Song("my future", new List<Artist>(), Genre.Pop, 210),
                    new Song("Oxytocin", new List<Artist>(), Genre.Pop, 186)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "+", new List<Song>
                {
                    new Song("The A Team", new List<Artist>(), Genre.Pop, 244),
                    new Song("Drunk", new List<Artist>(), Genre.Pop, 201),
                    new Song("U.N.I.", new List<Artist>(), Genre.Pop, 210),
                    new Song("Grade 8", new List<Artist>(), Genre.Pop, 174),
                    new Song("Wake Me Up", new List<Artist>(), Genre.Pop, 210)
                }),
                new Album(new List<Artist>(), "x", new List<Song>
                {
                    new Song("One", new List<Artist>(), Genre.Pop, 257),
                    new Song("I'm a Mess", new List<Artist>(), Genre.Pop, 244),
                    new Song("Sing", new List<Artist>(), Genre.Pop, 231),
                    new Song("Don't", new List<Artist>(), Genre.Pop, 239),
                    new Song("Nina", new List<Artist>(), Genre.Pop, 223)
                }),
                new Album(new List<Artist>(), "÷", new List<Song>
                {
                    new Song("Eraser", new List<Artist>(), Genre.Pop, 223),
                    new Song("Castle on the Hill", new List<Artist>(), Genre.Pop, 261),
                    new Song("Dive", new List<Artist>(), Genre.Pop, 238),
                    new Song("Shape of You", new List<Artist>(), Genre.Pop, 233),
                    new Song("Perfect", new List<Artist>(), Genre.Pop, 263)
                }),
                new Album(new List<Artist>(), "No.6 Collaborations Project", new List<Song>
                {
                    new Song("Beautiful People", new List<Artist>(), Genre.Pop, 198),
                    new Song("South of the Border", new List<Artist>(), Genre.Pop, 203),
                    new Song("Cross Me", new List<Artist>(), Genre.Pop, 206),
                    new Song("Take Me Back to London", new List<Artist>(), Genre.Pop, 187),
                    new Song("Best Part of Me", new List<Artist>(), Genre.Pop, 219)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Good Girl Gone Bad", new List<Song>
                {
                    new Song("Umbrella", new List<Artist>(), Genre.Pop, 267),
                    new Song("Push Up on Me", new List<Artist>(), Genre.Pop, 196),
                    new Song("Don't Stop the Music", new List<Artist>(), Genre.Pop, 246),
                    new Song("Breakin' Dishes", new List<Artist>(), Genre.Pop, 223),
                    new Song("Shut Up and Drive", new List<Artist>(), Genre.Pop, 211)
                }),
                new Album(new List<Artist>(), "Loud", new List<Song>
                {
                    new Song("S&M", new List<Artist>(), Genre.Pop, 244),
                    new Song("What's My Name?", new List<Artist>(), Genre.Pop, 254),
                    new Song("Cheers (Drink to That)", new List<Artist>(), Genre.Pop, 244),
                    new Song("Fading", new List<Artist>(), Genre.Pop, 220),
                    new Song("Only Girl (In the World)", new List<Artist>(), Genre.Pop, 235)
                }),
                new Album(new List<Artist>(), "Talk That Talk", new List<Song>
                {
                    new Song("You Da One", new List<Artist>(), Genre.Pop, 211),
                    new Song("Where Have You Been", new List<Artist>(), Genre.Pop, 241),
                    new Song("We Found Love", new List<Artist>(), Genre.Pop, 217),
                    new Song("Talk That Talk", new List<Artist>(), Genre.Pop, 211),
                    new Song("Cockiness (Love It)", new List<Artist>(), Genre.Pop, 200)
                }),
                new Album(new List<Artist>(), "ANTI", new List<Song>
                {
                    new Song("Consideration", new List<Artist>(), Genre.Pop, 162),
                    new Song("James Joint", new List<Artist>(), Genre.Pop, 75),
                    new Song("Kiss It Better", new List<Artist>(), Genre.Pop, 249),
                    new Song("Work", new List<Artist>(), Genre.Pop, 219),
                    new Song("Desperado", new List<Artist>(), Genre.Pop, 180)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Doo-Wops & Hooligans", new List<Song>
                {
                    new Song("Grenade", new List<Artist>(), Genre.Pop, 223),
                    new Song("Just the Way You Are", new List<Artist>(), Genre.Pop, 220),
                    new Song("Our First Time", new List<Artist>(), Genre.Pop, 244),
                    new Song("Runaway Baby", new List<Artist>(), Genre.Pop, 151),
                    new Song("The Lazy Song", new List<Artist>(), Genre.Pop, 187)
                }),
                new Album(new List<Artist>(), "Unorthodox Jukebox", new List<Song>
                {
                    new Song("Young Girls", new List<Artist>(), Genre.Pop, 217),
                    new Song("Locked Out of Heaven", new List<Artist>(), Genre.Pop, 233),
                    new Song("Gorilla", new List<Artist>(), Genre.Pop, 244),
                    new Song("Treasure", new List<Artist>(), Genre.Pop, 178),
                    new Song("Moonshine", new List<Artist>(), Genre.Pop, 237)
                }),
                new Album(new List<Artist>(), "24K Magic", new List<Song>
                {
                    new Song("24K Magic", new List<Artist>(), Genre.Funk, 227),
                    new Song("Chunky", new List<Artist>(), Genre.Funk, 213),
                    new Song("Perm", new List<Artist>(), Genre.Funk, 225),
                    new Song("That's What I Like", new List<Artist>(), Genre.Funk, 187),
                    new Song("Versace on the Floor", new List<Artist>(), Genre.Funk, 273)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "The Fame", new List<Song>
                {
                    new Song("Just Dance", new List<Artist>(), Genre.Pop, 244),
                    new Song("LoveGame", new List<Artist>(), Genre.Pop, 213),
                    new Song("Paparazzi", new List<Artist>(), Genre.Pop, 217),
                    new Song("Poker Face", new List<Artist>(), Genre.Pop, 238),
                    new Song("Eh, Eh (Nothing Else I Can Say)", new List<Artist>(), Genre.Pop, 162)
                }),
                new Album(new List<Artist>(), "Born This Way", new List<Song>
                {
                    new Song("Marry the Night", new List<Artist>(), Genre.Pop, 265),
                    new Song("Born This Way", new List<Artist>(), Genre.Pop, 260),
                    new Song("Government Hooker", new List<Artist>(), Genre.Pop, 252),
                    new Song("Judas", new List<Artist>(), Genre.Pop, 260),
                    new Song("Americano", new List<Artist>(), Genre.Pop, 244)
                }),
                new Album(new List<Artist>(), "Joanne", new List<Song>
                {
                    new Song("Diamond Heart", new List<Artist>(), Genre.Pop, 230),
                    new Song("A-YO", new List<Artist>(), Genre.Pop, 192),
                    new Song("Joanne", new List<Artist>(), Genre.Pop, 190),
                    new Song("John Wayne", new List<Artist>(), Genre.Pop, 171),
                    new Song("Dancin' in Circles", new List<Artist>(), Genre.Pop, 211)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Let It Bleed", new List<Song>
                {
                    new Song("Gimme Shelter", new List<Artist>(), Genre.Rock, 270),
                    new Song("Love in Vain", new List<Artist>(), Genre.Blues, 261),
                    new Song("Country Honk", new List<Artist>(), Genre.Country, 187),
                    new Song("Live with Me", new List<Artist>(), Genre.Rock, 203),
                    new Song("Let It Bleed", new List<Artist>(), Genre.Rock, 325)
                }),
                new Album(new List<Artist>(), "Sticky Fingers", new List<Song>
                {
                    new Song("Brown Sugar", new List<Artist>(), Genre.Rock, 215),
                    new Song("Sway", new List<Artist>(), Genre.Rock, 221),
                    new Song("Wild Horses", new List<Artist>(), Genre.Country, 340),
                    new Song("Can't You Hear Me Knocking", new List<Artist>(), Genre.Rock, 431),
                    new Song("You Gotta Move", new List<Artist>(), Genre.Blues, 161)
                }),
                new Album(new List<Artist>(), "Exile on Main St.", new List<Song>
                {
                    new Song("Rocks Off", new List<Artist>(), Genre.Rock, 264),
                    new Song("Rip This Joint", new List<Artist>(), Genre.Rock, 142),
                    new Song("Shake Your Hips", new List<Artist>(), Genre.Blues, 177),
                    new Song("Casino Boogie", new List<Artist>(), Genre.Rock, 202),
                    new Song("Tumbling Dice", new List<Artist>(), Genre.Rock, 231)
                }),
                new Album(new List<Artist>(), "Beggars Banquet", new List<Song>
                {
                    new Song("Sympathy for the Devil", new List<Artist>(), Genre.Rock, 382),
                    new Song("No Expectations", new List<Artist>(), Genre.Blues, 235),
                    new Song("Dear Doctor", new List<Artist>(), Genre.Country, 211),
                    new Song("Parachute Woman", new List<Artist>(), Genre.Blues, 142),
                    new Song("Jig-Saw Puzzle", new List<Artist>(), Genre.Rock, 366)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Yours Truly", new List<Song>
                {
                    new Song("Honeymoon Avenue", new List<Artist>(), Genre.Pop, 353),
                    new Song("Baby I", new List<Artist>(), Genre.Pop, 211),
                    new Song("Right There", new List<Artist>(), Genre.Pop, 244),
                    new Song("Tattooed Heart", new List<Artist>(), Genre.Pop, 220),
                    new Song("Lovin' It", new List<Artist>(), Genre.Pop, 210)
                }),
                new Album(new List<Artist>(), "My Everything", new List<Song>
                {
                    new Song("Intro", new List<Artist>(), Genre.Pop, 65),
                    new Song("Problem", new List<Artist>(), Genre.Pop, 213),
                    new Song("One Last Time", new List<Artist>(), Genre.Pop, 198),
                    new Song("Why Try", new List<Artist>(), Genre.Pop, 207),
                    new Song("Break Free", new List<Artist>(), Genre.Pop, 215)
                }),
                new Album(new List<Artist>(), "Dangerous Woman", new List<Song>
                {
                    new Song("Moonlight", new List<Artist>(), Genre.Pop, 210),
                    new Song("Dangerous Woman", new List<Artist>(), Genre.Pop, 236),
                    new Song("Be Alright", new List<Artist>(), Genre.Pop, 163),
                    new Song("Into You", new List<Artist>(), Genre.Pop, 244),
                    new Song("Side to Side", new List<Artist>(), Genre.Pop, 223)
                }),
                new Album(new List<Artist>(), "Sweetener", new List<Song>
                {
                    new Song("Raindrops (An Angel Cried)", new List<Artist>(), Genre.Pop, 37),
                    new Song("Blazed", new List<Artist>(), Genre.Pop, 180),
                    new Song("The Light Is Coming", new List<Artist>(), Genre.Pop, 196),
                    new Song("REM", new List<Artist>(), Genre.Pop, 214),
                    new Song("God is a woman", new List<Artist>(), Genre.Pop, 197)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Stoney", new List<Song>
                {
                    new Song("Broken Whiskey Glass", new List<Artist>(), Genre.HipHop, 233),
                    new Song("Big Lie", new List<Artist>(), Genre.HipHop, 223),
                    new Song("Deja Vu", new List<Artist>(), Genre.HipHop, 223),
                    new Song("No Option", new List<Artist>(), Genre.HipHop, 219),
                    new Song("Cold", new List<Artist>(), Genre.HipHop, 265)
                }),
                new Album(new List<Artist>(), "Beerbongs & Bentleys", new List<Song>
                {
                    new Song("Paranoid", new List<Artist>(), Genre.HipHop, 211),
                    new Song("Spoil My Night", new List<Artist>(), Genre.HipHop, 215),
                    new Song("Rich & Sad", new List<Artist>(), Genre.HipHop, 227),
                    new Song("Zack and Codeine", new List<Artist>(), Genre.HipHop, 210),
                    new Song("Takin' Shots", new List<Artist>(), Genre.HipHop, 221)
                }),
                new Album(new List<Artist>(), "Hollywood's Bleeding", new List<Song>
                {
                    new Song("Hollywood's Bleeding", new List<Artist>(), Genre.HipHop, 156),
                    new Song("Saint-Tropez", new List<Artist>(), Genre.HipHop, 153),
                    new Song("Enemies", new List<Artist>(), Genre.HipHop, 211),
                    new Song("Allergic", new List<Artist>(), Genre.HipHop, 122),
                    new Song("A Thousand Bad Times", new List<Artist>(), Genre.HipHop, 205)
                }),
                new Album(new List<Artist>(), "Twelve Carat Toothache", new List<Song>
                {
                    new Song("Reputation", new List<Artist>(), Genre.HipHop, 210),
                    new Song("Cooped Up", new List<Artist>(), Genre.HipHop, 163),
                    new Song("Lemon Tree", new List<Artist>(), Genre.HipHop, 210),
                    new Song("Wrapped Around Your Finger", new List<Artist>(), Genre.HipHop, 181),
                    new Song("I Like You (A Happier Song)", new List<Artist>(), Genre.HipHop, 188)
                })
            },
            new List<Album>
            {
                new Album(new List<Artist>(), "Homework", new List<Song>
                {
                    new Song("Daftendirekt", new List<Artist>(), Genre.Electronic, 164),
                    new Song("WDPK 83.7 FM", new List<Artist>(), Genre.Electronic, 28),
                    new Song("Revolution 909", new List<Artist>(), Genre.Electronic, 320),
                    new Song("Da Funk", new List<Artist>(), Genre.Electronic, 330),
                    new Song("Phoenix", new List<Artist>(), Genre.Electronic, 289)
                }),
                new Album(new List<Artist>(), "Discovery", new List<Song>
                {
                    new Song("One More Time", new List<Artist>(), Genre.Electronic, 320),
                    new Song("Aerodynamic", new List<Artist>(), Genre.Electronic, 211),
                    new Song("Digital Love", new List<Artist>(), Genre.Electronic, 300),
                    new Song("Harder, Better, Faster, Stronger", new List<Artist>(), Genre.Electronic, 224),
                    new Song("Crescendolls", new List<Artist>(), Genre.Electronic, 210)
                }),
                new Album(new List<Artist>(), "Human After All", new List<Song>
                {
                    new Song("Human After All", new List<Artist>(), Genre.Electronic, 320),
                    new Song("The Prime Time of Your Life", new List<Artist>(), Genre.Electronic, 270),
                    new Song("Robot Rock", new List<Artist>(), Genre.Electronic, 276),
                    new Song("Steam Machine", new List<Artist>(), Genre.Electronic, 320),
                    new Song("Make Love", new List<Artist>(), Genre.Electronic, 305)
                }),
                new Album(new List<Artist>(), "Random Access Memories", new List<Song>
                {
                    new Song("Give Life Back to Music", new List<Artist>(), Genre.Electronic, 273),
                    new Song("The Game of Love", new List<Artist>(), Genre.Electronic, 331),
                    new Song("Giorgio by Moroder", new List<Artist>(), Genre.Electronic, 569),
                    new Song("Within", new List<Artist>(), Genre.Electronic, 227),
                    new Song("Instant Crush", new List<Artist>(), Genre.Electronic, 337)
                })
            }
        };

        public List<Artist> artists = new List<Artist>
        {
            new Artist("The Beatles", new List<Album>()),
            new Artist("Taylor Swift", new List<Album>()),
            new Artist("Queen", new List<Album>()),
            new Artist("Adele", new List<Album>()),
            new Artist("Beyoncé", new List<Album>()),
            new Artist("Coldplay", new List<Album>()),
            new Artist("Billie Eilish", new List<Album>()),
            new Artist("Ed Sheeran", new List<Album>()),
            new Artist("Rihanna", new List<Album>()),
            new Artist("Bruno Mars", new List<Album>()),
            new Artist("Lady Gaga", new List<Album>()),
            new Artist("The Rolling Stones", new List<Album>()),
            new Artist("Ariana Grande", new List<Album>()),
            new Artist("Post Malone", new List<Album>()),
            new Artist("Daft Punk", new List<Album>())
        };

        public List<Album> albums => albumLists.SelectMany(albums => albums).ToList();

        public Constants()  
        {  
            for (int i = 0; i < artists.Count; i++)  
            {  
                foreach (var album in albumLists[i])  
                {  
                    artists[i].Albums.Add(album);  
                }  
            }  
        }  
    }
}
