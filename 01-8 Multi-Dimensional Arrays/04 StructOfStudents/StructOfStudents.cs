using System;

class StructOfStudents
{
    struct Student
    {
        public int ID;

        public string Name;

        public int Age;

        public char Gender;

        public int Score;

        public Student(int iD, string name, int age, char gender, int score)
        {
            this.ID = iD;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Score = score;
        }

        public override string ToString()
        {
            return "Numbah " + ID + ", name: " + Name + ", age: " + Age + ", gender: " + Gender + ", score: " + Score + " and the crowd goes wild~";
        }
    }

    static void Main()
    {
        Student[] marvelSuperheroes = new Student[10];
        marvelSuperheroes[0] = new Student(1, "Hulk", 47, 'm', 99);
        marvelSuperheroes[1] = new Student(2, "Ironman", 35, 'm', 80);
        marvelSuperheroes[2] = new Student(3, "Thor", 155, 'm', 85);
        marvelSuperheroes[3] = new Student(4, "Captain America", 73, 'm', 65);
        marvelSuperheroes[4] = new Student(5, "Antman", 29, 'm', 60);
        marvelSuperheroes[5] = new Student(6, "The Punisher", 45, 'm', 75);
        marvelSuperheroes[6] = new Student(7, "Spiderman", 33, 'm', 90);
        marvelSuperheroes[7] = new Student(8, "Black Widow", 23, 'f', 50);
        marvelSuperheroes[8] = new Student(9, "I AM GROOT", 450, 'm', 79);
        marvelSuperheroes[9] = new Student(10, "Doctor Strange", 52, 'm', 69);

        //Create an Array of 10 students and sort them by:
        //ID, Name, Name(reverse), Age, Score, Name Length and(first by Gender and then by Name).

        Array.Sort(marvelSuperheroes, (x, y) => x.ID.CompareTo(y.ID));      //id
        PrintThisSort(marvelSuperheroes);

        Array.Sort(marvelSuperheroes, (x, y) => x.Name.CompareTo(y.Name));  //name
        PrintThisSort(marvelSuperheroes);

        Array.Sort(marvelSuperheroes, (x, y) => y.Name.CompareTo(x.Name));   //name(reverse)
        PrintThisSort(marvelSuperheroes);

        Array.Sort(marvelSuperheroes, (x, y) => x.Age.CompareTo(y.Age));      //age
        PrintThisSort(marvelSuperheroes);

        Array.Sort(marvelSuperheroes, (x, y) => x.Score.CompareTo(y.Score));  //score
        PrintThisSort(marvelSuperheroes);

        Array.Sort(marvelSuperheroes, (x, y) => x.Name.Length.CompareTo(y.Name.Length));  //first name length
        Array.Sort(marvelSuperheroes, (x, y) => x.Gender.CompareTo(y.Gender));            //then gender
        PrintThisSort(marvelSuperheroes);

        Array.Sort(marvelSuperheroes, (x, y) => x.Name.Length.CompareTo(y.Name.Length));   //first name length
        Array.Sort(marvelSuperheroes, (x, y) => x.Name.CompareTo(y.Name));                 //then name
        PrintThisSort(marvelSuperheroes);

    }

    private static void PrintThisSort(Student[] marvelSuperheroes)
    {
        for (int i = 0; i < marvelSuperheroes.Length; i++)
        {
            Console.WriteLine(marvelSuperheroes[i].ToString());
        }
        Console.WriteLine(new string('-', 90));
    }
}