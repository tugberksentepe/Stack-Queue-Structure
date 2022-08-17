class Program
    {
        //QUEUE (KUYRUK) yapısını inceleyeceğiz.

        //last in last out LİLO             Stack
        //first in first out FİFO           Kuyruk
        
        
        //Kuyrukta hizmet alacaklar front
        static int front = -1;
        //Kuyrukta sıraya dahil olacaklar rear
        static int rear = 0;
        //Kuyruk
        static int[] queue = new int[100];
        
        
        class Block //Blok yapımızı tanımlamayı unutmayalım.
        {
            public int data;
            public Block next;
            public Block prev;
        }
       
        static Block Front = null;
        static Block Rear = null;

        static int Delete()
        {
            int data = Front.data;
            Front = Front.next;
            /*if (Front == null) { Rear = null; }*/   //İŞARET
            return data;
             
        }
        static void Ekleme(int data)
        {
            Block bl = new Block();
            bl.data = data;
            bl.next = null;
            if (Front == null) { Front = bl;Rear = bl; }
            else
            {
                Rear.next = bl;
                bl.prev = Rear;
                Rear = bl;
            }
            //if (Front == null) Front = bl;  Delete kısmındaki işaretli satırın 2. çözüm satırı
        }

        static void enqueue(int data)
        {    
            queue[rear] = data;
            rear++;
            if (rear >= queue.Length) move();
        }
        static void Enqueue(int data)
        {
            queue[rear] = data;
            rear++;
            rear = rear % queue.Length;
        }
        static int Dequeue()
        {
            front++;
            front = front % queue.Length;
            int data = queue[front];
            return data;

        }
        static void move()
        {
            for (int i = front; i <rear; i++)
            {
                queue[i-front]= queue[i];
            }
            rear = rear - front;
            front = 0;
        }
        static int dequeue()
        {
            front++;
            int data = queue[front];
            return data;
        }

        
        static void Main(string[] args)
        {
            for (int i = 0; i < 80; i++)
            {
                Ekleme(i);
            }
            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine(Delete());
            }
            for (int i = 0; i < 80; i++)
            {
                Ekleme(i);
            }
            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine(Delete());
            }
        }
    }