namespace Lab_2;
//Sources used ChatGPT, StackOverflow, Reddit, peers
class Program
{
    static void Main(string[] args)
    {
        List<VideoGame> listofGames = new List<VideoGame>(); //makes a new list for video games...referencing the video game class. 

        Dictionary<int, VideoGame> gameDictionary = new Dictionary<int, VideoGame>();  //creates a int key and game object..using this to make a dictironary 

        Stack<VideoGame> yourStack = new Stack<VideoGame>(); //creates a stack for video games

        Queue<VideoGame> gameQueue = new Queue<VideoGame>(); //Creates a queue for the video games

        string rootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString(); //makes a new directory so that it can find the csv file easier?
        string filePath = $"{rootFolder}{Path.DirectorySeparatorChar}videogames.csv";  //establishes a file path to videogames.csv

        

        using (var sr = new StreamReader(filePath))
        {
            string[] fileReader = File.ReadAllLines(filePath);



            for (int gameNumber = 1; gameNumber < fileReader.Length; gameNumber++)
            {
                string line = fileReader[gameNumber];

                string[] lineElements = line.Split(',');

                VideoGame Games = new VideoGame
                {
                    Name = lineElements[0],
                    Platform = lineElements[1],
                    Genre = lineElements[3],
                    Publisher = lineElements[4],

                };

                gameDictionary.Add(gameNumber, Games);
            }

            //User's Curernt Games
            VideoGame game1 = new VideoGame
            {
                Name = "Fortnite",
                Platform = "PS5",
                Genre = "Battle Royale",
                Publisher = "EPIC Games"
            };

            VideoGame game2 = new VideoGame
            {
                Name = "Splatoon 3",
                Platform = "Nintendo",
                Genre = "Shooter",
                Publisher = "Nintendo"
            };

            VideoGame game3 = new VideoGame
            {
                Name = "Horizon: Zero Dawn",
                Platform = "PS5",
                Genre = "Adventure",
                Publisher = "Sony Interactive Entertainment"
            };

            VideoGame game4 = new VideoGame
            {
                Name = "Marvel's Spider-Man: Miles Morales",
                Platform = "PS5",
                Genre = "Adventure",
                Publisher = "Sony Interactive Entertainment"
            };

            VideoGame game5 = new VideoGame
            {
                Name = "NieR Automata",
                Platform = "PS4",
                Genre = "Action",
                Publisher = "Square Enix"
            };

            
            yourStack.Push(game1);
            yourStack.Push(game2);
            yourStack.Push(game3);
            yourStack.Push(game4);
            yourStack.Push(game5);

           
            try
            {
                    Console.WriteLine("Hey! Welcome to the Random Game Picker! How this works is you pick a random number," +
                        "and the number you pick is the game you'll play! So! Pick any number between 1 - 16328.");

                    int userNum = Int32.Parse(Console.ReadLine());

                if (userNum < 1 || userNum > gameDictionary.Keys.Count)
                {
                    Console.WriteLine("Enter a valid number.");
                }
                else
                {
                    Console.WriteLine($"Great, you've chosen the number {userNum}");

                }

                    if (gameDictionary.TryGetValue(userNum, out VideoGame chosenGame))
                    {




                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Congrats! The game you'll be playing is..");

                            Console.WriteLine($"Game: {chosenGame.Name}");
                            Console.WriteLine($"Game Publisher: {chosenGame.Publisher}");
                            Console.WriteLine($"Game Genre: {chosenGame.Genre}");
                            Console.WriteLine($"Have fun!");
                            Console.WriteLine("-----------------------");

                          
                            Console.WriteLine($"Now that you've added {chosenGame.Name} to your game library, lets see what you currently have.\n");

                            yourStack.Push(chosenGame);

                            foreach (var game in yourStack)
                            {
                                Console.WriteLine($"Game: {game.Name}");
                                Console.WriteLine($"Game Publisher: {game.Publisher}");
                                Console.WriteLine($"Game Genre: {game.Genre}\n");
                            }

                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();

                            Console.WriteLine("Oops! Your brother just stole your new game. Me personally I wouldn't take that but you know...");
                            VideoGame stolenGame = yourStack.Pop();
                            Console.WriteLine($"{stolenGame.Name} is now missing from your library.\n");

                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();

                            Console.WriteLine("Since you weren't able to play that game, another game has been added to your game library.\n");
                            VideoGame replacementGame = new VideoGame
                            {
                                Name = "Final Fantasy VII",
                                Platform = "PS5",
                                Genre = "Adventure",
                                Publisher = "Square Enix"

                            }; 

                            yourStack.Push(replacementGame);

                            foreach (var game in yourStack)
                            {
                                gameQueue.Enqueue(game);
                            }


                    Console.WriteLine($"{replacementGame.Name} has been added to your game libary");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Your Game Library [Last Updated: A Few Seconds Ago]\n");

                            foreach (var game in yourStack)
                            {
                                Console.WriteLine($"Game: {game.Name}");
                                Console.WriteLine($"Game Publisher: {game.Publisher}");
                                Console.WriteLine($"Game Genre: {game.Genre}\n");
                            }

                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Congrats, you get to choose another game, same rules as before: Pick a number between 1 - 16328.");
                            int userNum2 = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("-----------------------");

                        if (gameDictionary.TryGetValue(userNum2, out VideoGame anotherFreeGame))
                        {
                            Console.WriteLine($"Game: {anotherFreeGame.Name}");
                            Console.WriteLine($"Game Publisher: {anotherFreeGame.Publisher}");
                            Console.WriteLine($"Game Genre: {anotherFreeGame.Genre}");
                            Console.WriteLine($"Have fun!");
                            Console.WriteLine("-----------------------");

                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                           

                            Console.WriteLine($"Uh oh, it looks like you don't have enough space to download {anotherFreeGame.Name}.\n");
                            Console.WriteLine($"Looks like you're gonna have to delete a game...or spend like $200 on an external hard drive..\n");

                        }
                            if (gameQueue.Count > 0)
                            {
                                Console.WriteLine("So, which game would you like to delete from your library? 1 - 6.");
                                int gameRemove = Int32.Parse(Console.ReadLine());

                                if(gameRemove >= 1 && gameRemove <= gameQueue.Count)
                                {
                                    for(int i = 1; i < gameRemove; i++)
                                    {
                                        gameQueue.Enqueue(gameQueue.Dequeue());
                                        
                                    }

                                    VideoGame deletedGame = gameQueue.Dequeue();
                                    Console.WriteLine($"{deletedGame.Name} has been successfully deleted from the library.\n");

                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                   

                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Your Game Library [Last Updated: A Few Seconds Ago]\n");

                                    foreach (var game in gameQueue)
                                    {
                                        Console.WriteLine($"Game: {game.Name}");
                                        Console.WriteLine($"Game Publisher: {game.Publisher}");
                                        Console.WriteLine($"Game Genre: {game.Genre}\n");
                                    }

                                     Console.WriteLine($"{anotherFreeGame.Name} can now be downloaded. Downloading in progress...");
                                     Console.WriteLine("Press enter to continue");
                                     Console.ReadLine();

                                     Console.WriteLine($"{anotherFreeGame.Name} has successfully been downloaded!\n");
                                     gameQueue.Enqueue(anotherFreeGame);

                                    Console.WriteLine("-----------------------");
                                    Console.WriteLine("Your Game Library [Last Updated: A Few Seconds Ago]\n");
                                     

                                    foreach (var game in gameQueue)
                                    {
                                        Console.WriteLine($"Game: {game.Name}");
                                        Console.WriteLine($"Game Publisher: {game.Publisher}");
                                        Console.WriteLine($"Game Genre: {game.Genre}\n");
                                    }

                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();

                                    Console.WriteLine("That's all for now. Step outside and touch some grass.");
                                    Console.WriteLine("Press Enter to exit the program.");
                                    Console.ReadLine();
                                }

                                else
                                {
                                    Console.WriteLine("Invalid Game Number. Pick a game you have.");
                                }
                            }

                            else
                            {
                                Console.WriteLine("Something went wrong.");
                            }

                           
                    }




                else
                {
                    Console.WriteLine("Game not found. There was a problem retrieving the data.");
                }


            }
                

            catch (Exception ex)
            {
                    Console.WriteLine("There was an error.");
            }





        }

      
    }

}