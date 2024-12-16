namespace yam
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstExam { get; set; }
        public int ScondExam { get; set; }
        public string Grade { get; set; }
        public double Average { get; set; }
        public Student Next { get; set; }
        public Student(int id, string name, int firstexam, int scondexam)
        {
            Id = id;
            Name = name;
            FirstExam = firstexam;
            ScondExam = scondexam;
            Average = Avg();
            Grade = grade(Average);
            Next = null;




        }
        private double Avg()
        {
            return (FirstExam + ScondExam) / 2;
        }
        private string grade(double Avg)
        {
            if (Avg < 60)
            {
                return "bad";
            }
            else if (Avg < 75)
            {
                return "Good";
            }
            else if (Avg < 85)
            {
                return "Very Good";
            }
            else
            {
                return "excellent";
            }
        }
    }

    // Define the linked list structure
    class StudentLinkedList
    {
        private Student head;

        public void AddStudent(Student student)
        {




            if (head == null)
            {
                head = student;
            }
            else
            {
                Student current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = student;
            }
        }

        // Sort the list by average score
        public void SortStudents()
        {
            if (head == null || head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                Student current = head;
                Student previous = null;

                while (current.Next != null)
                {
                    if (current.Average > current.Next.Average)
                    {

                        if (previous == null)
                        {
                            Student temp = current.Next;
                            current.Next = temp.Next;
                            temp.Next = current;
                            head = temp;
                        }
                        else
                        {
                            Student temp = current.Next;
                            current.Next = temp.Next;
                            temp.Next = current;
                            previous.Next = temp;
                        }
                        swapped = true;
                    }
                    previous = current;
                    current = current.Next;
                }
            } while (swapped);
        }

        // Print all students in the list
        public void PrintStudents()
        {
            Student current = head;
            while (current != null)
            {
                Console.WriteLine($"id : {current.Id} - Name : {current.Name} - Mark1 : {current.FirstExam} - Mark2 : {current.ScondExam} - Grade : {current.Grade} - Average : {current.Average}");
                current = current.Next;
            }
        }
    }


    class Program
    {

        static void Main()
        {

            // Create a new linked list for students

            var studentList = new StudentLinkedList();
            Student r1 = new Student(1, "Yamen", 80, 95);
            Student r2 = new Student(2, "Mohamed", 10, 40);
            Student r3 = new Student(3, "Samer", 80, 80);
            Student r4 = new Student(4, "Ahmed", 100, 100);
            studentList.AddStudent(r1);
            studentList.AddStudent(r2);
            studentList.AddStudent(r3);
            studentList.AddStudent(r4);




            Console.WriteLine("Student list before sorting:");
            studentList.PrintStudents();


            studentList.SortStudents();


            Console.WriteLine("Student list after sorting:");
            studentList.PrintStudents();
        }
    }



}
