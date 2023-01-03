namespace Indexers
{
    public struct MyVector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public MyVector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float this [int index]
        {
            get
            {
                if (index == 0) { return X;}
                else if (index ==1) {return Y;}
                else { throw new IndexOutOfRangeException();}
            }

            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else throw new IndexOutOfRangeException();
            }
        }

        private static string indx0 = "xa0";
        private static string indx1 = "yb1";

        public float this[string index]
        {
            get
            {
              index = index?.ToLower() ?? "";

              if(index.Length == 1)
              {
                if (indx0.Contains(index))
                    return X;
                else if (indx1.Contains(index))
                    return Y;
              } 
              throw new IndexOutOfRangeException();
            }

            set
            {
               index = index?.ToLower() ?? "";

              if(index.Length == 1)
              {
                if (indx0.Contains(index))
                    X = value;
                else if (indx1.Contains(index))
                    Y = value;
                else throw new IndexOutOfRangeException();
              } 
              else throw new IndexOutOfRangeException(); 
            }
        }
    }
}