namespace funWithInheritance
{
    class Galaxy
    {
        private string _Name;
        private string _Oxygen;
        private string _Water;
        private string _Gravity;

        public Galaxy()
        {
            _Name = "";
            _Oxygen = "";
            _Water = "";
            _Gravity = "";
        }
        public Galaxy(string name, string oxygen, string water, string gravity)
        {
            _Name = name;
            _Oxygen = oxygen;
            _Water = water;
            _Gravity = gravity;
        }
        public string getName() { return _Name;}
        public string getOxygen() { return _Oxygen;}
        public string getWater() { return _Water;}
        public string getGravity() { return _Gravity;}
        public void setName(string name) { _Name = name; }
        public void setOxygen(string oxygen) { _Oxygen = oxygen;}
        public void setWater(string water) { _Water = water;}

        public void setGravity(string gravity) { _Gravity = gravity;}

        public virtual void addChange()
        {
            Console.WriteLine("What is it's name?");
            setName(Console.ReadLine());
            Console.WriteLine("Is there oxygen here?"); 
            setOxygen(Console.ReadLine());
            Console.WriteLine("Is there water here?");
            setWater(Console.ReadLine());
            Console.WriteLine("What is the gravity here?");
            setGravity(Console.ReadLine());
        }
        public virtual void display()
        {
            Console.WriteLine($"Name: {getName()}");
            Console.WriteLine($"Oxygen: {getOxygen()}");
            Console.WriteLine($"Water: {getWater()}");
            Console.WriteLine($"Gravity: {getGravity()}");
        }

    }
    class Planet : Galaxy
    {
        private string _Weight;
        private string _Size;

        public Planet()
            : base()
        {
            _Weight = "";
            _Size = "";
        }
        public Planet(string name, string oxygen, string water, string gravity, string weight, string size)
            : base(name, oxygen, water, gravity)
        {
            _Weight = weight;
            _Size = size;
        }
        public void setWeight(string weight) {_Weight = weight;} 
        public void setSize(string size) { _Size = size;}
        public string getWeight() { return _Weight;}
        public string getSize() { return _Size;}
        public override void addChange()
        {
            base.addChange();
            Console.WriteLine("What is the weight?");
            setWeight(Console.ReadLine());
            Console.WriteLine("What is the size?");
            setSize(Console.ReadLine());
        }
        public override void display()
        {
            base.display();
            Console.WriteLine($"Weight: {getWeight()}");
            Console.WriteLine($"Size: {getSize()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many galaxies do you want to enter?");
            int maxGalaxies;
            while (!int.TryParse(Console.ReadLine(), out maxGalaxies))
                Console.WriteLine("Please enter a whole number.");
            Galaxy[] galax = new Galaxy[maxGalaxies]; //creating an array of objects with size depending on user input

            Console.WriteLine("How many planets do you want to enter?");
            int maxPlanets;
            while (!int.TryParse(Console.ReadLine(), out maxPlanets))
                Console.WriteLine("Please enter a whole number.");
            Planet[] plnts= new Planet[maxPlanets]; //creating another array of objects

            int userInput, rec, type;
            int galaxyCounter = 0, planetCounter = 0;
            userInput = Menu();
            while(userInput!= 4)
            {
                Console.WriteLine("Enter '1' for Galaxy or '2' for Planet.");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("Enter '1' for Galaxy or '2' for Planet.");
                try
                {
                    switch(userInput)
                    {
                        case 1: //Add
                            if(type == 1) // Galaxy
                            {
                                if (galaxyCounter <= maxGalaxies)
                                {
                                    galax[galaxyCounter] = new Galaxy(); //places an object in the array 
                                    galax[galaxyCounter].addChange();
                                    galaxyCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of galaxies has been added.");
                            }
                            else // Planet
                            {
                                if (planetCounter <= maxPlanets)
                                {
                                    plnts[planetCounter] = new Planet();
                                    plnts[planetCounter].addChange();
                                    planetCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of planets has been added.");
                            }
                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you would like to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--; //substracting one from the record number because the array index begins at 0
                            if(type == 1) //galaxy
                            {
                                while (rec > galaxyCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered is out of range, try again.");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                galax[rec].addChange();
                            }
                            else // planets
                            {
                                while(rec > planetCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered is out of range, try again.");
                                    while (!int.TryParse(Console.ReadLine(), out rec));
                                    Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                plnts[rec].addChange();
                            }
                            break;
                        case 3: // print all
                            if(type== 1) //galaxy
                            {
                                for (int i = 0; i < galaxyCounter; i++) 
                                    galax[i].display();
                            }
                            else
                            {
                                for(int i = 0; i < planetCounter; i++)
                                    plnts[i].display();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection. Please try again!");
                            break;
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                userInput = Menu();
            }

            

        }

        private static int Menu()
        {
            int selection = 0;
            Console.WriteLine("Make a selection from the menu.");
            Console.WriteLine("1 - Add, 2 - Change, 3 - Print, 4 - Quit");
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1 - Add, 2 - Change, 3 - Print, 4 - Quit");
            return selection;
        }
    }
}