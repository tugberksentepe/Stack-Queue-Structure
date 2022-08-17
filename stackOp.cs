 class Program

    {
        static void Main(string[] args)
        {   

            //INFIX VE POSTFIX ifadelerin Stacklerle kod yapısı:

            string infix = "a*b+c-d/f";
            string postfix = "";
            Stack<char> st = new Stack<char>();
            string op = "$+-*/()";
            string deger = "0112200";

            st.Push('$');

            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];
                int degerIndex = op.IndexOf(ch);
                if (op.IndexOf(ch)==-1) { postfix = postfix + ch; continue; } 
                if (ch=='(') { st.Push(ch); continue; }
                if (ch==')') {
                    while (st.Peek() != '(')
                        postfix = postfix + st.Pop();
                    st.Pop();
                    continue;
                }
                if (deger[degerIndex]>deger[ op.IndexOf(st.Peek())])
                { st.Push(ch); continue; }
                while (deger[degerIndex] <= deger[op.IndexOf(st.Peek())])
                    postfix = postfix + st.Pop();
                st.Push(ch);
            }
            while (st.Count>= 2) postfix = postfix + st.Pop();
            Console.WriteLine(infix);
            Console.WriteLine(postfix);


            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");


            //Aşağıda verilen string text ifadesinde yer alan açılan parantezlerin kapatılıp kapatılmadığının  
            //kontorlünü STACK yapısı ile nasıl sağlarız? Sorusunun çözümü:

            string text = "(([{ { () }} ] ) }";
            string sol = "({[";
            string sag = ")}]";
        
            Stack<char> st = new Stack<char>();
        
            bool hata = false;
            // abcdefghjk
            for (int i = 0; i < text.Length; i++)
            {
                if (sol.IndexOf(text[i]) != -1) st.Push(text[i]);
                if (sag.IndexOf(text[i]) != -1) 
                {
                    char ch = st.Pop();
                    int a = sag.IndexOf(text[i]);
                    if (sol[a] != ch) { hata = true; break; }
                }
            }
            if (st.Count >= 1) hata = true;
            if (hata) Console.WriteLine("hata");
                         else Console.WriteLine("doğru");


            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");             
                    

            
            //Postfix ifadeyi değişkenlerin değerlerini yerine koyarak sayısal bir matematiksel işlem ifadesine çevireceğiz

            int a = 1;
            int b = 2;
            int c = 3;
            c = c + b + a;
            string postfix = "ab*c/d+f-"; //a*b/c+d-f
            // a=2; b=3; c=1; d=5; e=2; Sonuç 9 olacak.
            // Operand pop 2 değer hesaplama yap push
            // Stacktaki değer bizim sonucumuz olur bu döngüde

            Stack<int> st = new Stack<int>();
            string op = "+-*/";
            string operand = "abcdf";
            int[] values = { 2, 3, 1, 5, 0, 2 };//new int[6];

            for (int i = 0; i < postfix.Length; i++)
            {
               if (operand.IndexOf(postfix[1]) != -1)
               { int indis = operand.IndexOf(postfix[i]);
                   st.Push(values[indis]);
                   continue;
               }
               int e2 = st.Pop();//eleman2
               int e1 = st.Pop();//eleman1
               int sonuc = 0;
               if (postfix[i] == '+')  sonuc = e1 + e2; // veya methodda kullanılabilir topla(e1,e2); gibi
               else if (postfix[i] == '-') sonuc = e1 - e2;
               else if (postfix[i] == '*') sonuc = e1 * e2;
               else if (postfix[i] == '/') sonuc = e1 / e2;

               st.Push(sonuc);
            }
            Console.WriteLine(st.Pop());


        }
        
        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }

        static int topla(int a, int b)
        {
            return a + b;
        }

        static string[] stack = new string[100];
        
        //Block yapısı ile stack kullanımı için gerekli olan fonksiyonlar

        static void Push(int data)
        {
            Block temp = new Block();
            temp.data = data;
            temp.next = null;
            temp.prev = sp;

            if (sp == null) { sp = temp; return; }
            sp.next = temp;
            sp = temp;

            //   sp>   <sp|    <sp

        }
        static int Pop()
        {
            int data = sp.data;
            sp = sp.prev;
            // sp.next=null;
            return data;
        }

        static Block sp = null;
    }
}
