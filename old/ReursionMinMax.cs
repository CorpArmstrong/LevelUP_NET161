  // 2 - a
        static string Chisla(int a, int b)
        {                    
            if ( a == b )  // 1
            {
               return a.ToString();
           }

           
            // a--->b 
            //if (a > b)
            //{
            //    return a.ToString() + " " + Chisla(a - 1, b);  // 3.1
            //}
            //else
            //{
            //    return a.ToString() + " " + Chisla(a + 1, b);  // 3.2
            //}
            // b--->a
            if (a > b)
            {
                return Chisla(a - 1, b) + " " + a.ToString();  // 3.1
            }
            else
            {
                return Chisla(a + 1, b) + " " + a.ToString();  // 3.2
            }
        }