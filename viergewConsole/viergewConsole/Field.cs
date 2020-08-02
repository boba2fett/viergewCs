using System;
using System.Collections.Generic;
using System.Text;

namespace viergewConsole
{
    using System;

    class BitArray
    {
        int[] bits;
        int length;

        public BitArray(int length)
        {
            if (length < 0) throw new ArgumentException();
            bits = new int[((length - 1) >> 5) + 1];
            this.length = length;
        }

        public int Length
        {
            get { return length; }
        }

        public bool this[int index]
        {
            get
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException();
                }
                return (bits[index >> 5] & 1 << index) != 0;
            }
            set
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException();
                }
                if (value)
                {
                    bits[index >> 5] |= 1 << index;
                }
                else
                {
                    bits[index >> 5] &= ~(1 << index);
                }
            }
        }
    }


    class BitArray2D
    {
        int[,] bits;
        int width;
        int height;

        public BitArray2D(int width,int height)
        {
            if (width < 0||height<0) throw new ArgumentException();
            bits = new int[((width - 1) >> 5) + 1,height];
            this.width = width;
            this.height = height;
        }

        public int Length
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public bool this[int windex,int hindex]
        {
            get
            {
                if (windex < 0 || windex >= width||hindex<0||hindex>height)
                {
                    throw new IndexOutOfRangeException();
                }
                return (bits[windex >> 5,height] & 1 << windex) != 0;
            }
            set
            {
                if (windex < 0 || windex >= width||hindex<0||hindex>height)
                {
                    throw new IndexOutOfRangeException();
                }
                if (value)
                {
                    bits[windex >> 5,height] |= 1 << windex;
                }
                else
                {
                    bits[windex >> 5,height] &= ~(1 << windex);
                }
            }
        }
    }

    class Field
    {
        BitArray2D used;
        BitArray2D player;

        public Field(int w, int h)
        {
            used = new BitArray2D(w, h);
            player = new BitArray2D(w, h);
        }
    }
}
