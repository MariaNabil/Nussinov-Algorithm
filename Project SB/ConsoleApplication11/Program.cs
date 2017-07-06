using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace bioinformatics_1
{
    class Program
    {

        static char[] ch;
        static bool complement(char c1, char c2)
        {
            if ((c1 == 'A' && c2 == 'U') || (c1 == 'U' && c2 == 'A') || (c1 == 'C' && c2 == 'G') || (c1 == 'G' && c2 == 'C'))
            {
                return true;
            }
            else 
                return false;
        }
        static int [,] fm(string s1, string s2)
        {
            /*int m = s1.Length;
            string[] M1 = new string[10];
            M1[0] = "hello";
          //  cout << <<endl;
           Console.WriteLine(M1[0][0]);
            */
            
            int m = s1.Length;
           // int n = s2.Length;
            int[,] M = new int[m , m];

         /*   for (int i = 0; i < m; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    M[i, j] = 1;

                }


            }
          */

            for (int i = 0; i < m;i++ )
            {
                M[i, i] = 0;
            }

            for (int i = 1; i <m ; i++)
            {
                for (int j = 0; j <= i;j++ )
                    M[i,  i-j] = 0;
            }

                


            M[0, 0] = 0;
         /*   for (int u = 0; u < m; u++)
            {
                for (int w = 0; w < m; w++)
                {
                    if (u == w)
                    {
                        M[u, w] = 0;

                    }
                    if (u < w)
                    {

                        M[u, w] = 0;
                    }





                }

            }*/



            return M;
        }


        static public int[,] Fill_mat(string seq)
        {

            int s;
            int len = seq.Length;
            int[,] matrix = new int[len, len];
            int case1;
            int case2;
            int case3;
            int case4;
            int[] mat;
            int i;
            int j;
            int n;
            for (int x = 0; x < len; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    i = y;
                    j = y + x + 1;
                    if (j >= len)
                        break;
                    //s = j - i;
                    //  cas1 = matrix[s + 1, j - 1] + delta(mat[s], mat[j]);
                    if (false)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }

                    else
                    {

                        //case1 = matrix[i + 1, j - 1] + 1;
                        case2 = matrix[i + 1, j];
                        case3 = matrix[i, j - 1];
                        case4 = 0;
                        for (int k = i + 1; k < j;k++ )
                        {
                            if(case4<(matrix[i,k]+matrix[k+1,j]))
                            {
                                case4 = matrix[i, k] + matrix[k + 1, j];
                            }
                        }


                        if (complement(seq[i], seq[j]) == true)
                        {
                            case1 = matrix[i + 1, j - 1] + 1;
                        }
                        else
                            case1 = matrix[i + 1, j - 1] + 0;
                        matrix[i, j] = Math.Max(Math.Max(Math.Max(case1, case2), case3), case4);
                          /*  if (complement(seq[i], seq[j]) == true)
                            {
                                matrix[i, j] = Math.Max(Math.Max(Math.Max(case1, case2), case3),case4);
                            }
                            else
                                matrix[i, j] = Math.Max(case3, case2);
                        */
                        /*  if (i + 3 <= j)
                          {
                              for (int k = i + 1; k < j; k++)
                              {
                                  //int []m;
                                  // int[] t = new int[i, k];
                                  //t+= [k + 1, j];
                                  n = (matrix[i, k] + matrix[k + 1, j]);
                                  //case4 = Math.Max(n);
                              }
                          }
                         */
                    }

                }
            }
            return matrix;
        }




        /*
      static string Traceback(int[,] mat,string seq,int s, int j,string Pair )
    {
           if(s<j)
           {
               if(mat[s,j]== mat[s+1,j])
               {
                   Traceback(mat, seq, s + 1, j, Pair);
                   Pair += ')';
               }
               else if (mat[s, j] == mat[s , j-1])
               {
                   Traceback(mat, seq, s , j-1, Pair);
                   Pair += ')';
               }
               else if (mat[s, j] == mat[s+1, j - 1]+1)
               {
                   Pair += '(';
                   Traceback(mat, seq, s+1, j - 1, Pair);
                   Pair += ')';
               }
            /*   else
               {
                   for(int n=s+1;n<=j;n++)
                   {
                       if(mat[s, j] == mat[s, n]+mat[n+1, j])
                       {
                           Traceback(mat, seq, s , n, Pair);
                           // Traceback(mat, seq, n+1 , j, Pair);
                       }
                   }
               }
             
           }
           return Pair;
    }
        */

      public static char[] traceback(int[,] matrix, string seq, int i, int j)
      {
          String s = "";
         // s = "hellooooooo";
          bool see = complement(seq[i], seq[j]);
          if (i >= j)
              return ch;
          
          else if (matrix[i, j] == matrix[i, j - 1])
          {
             // s = s + ".";
              traceback(matrix, seq, i, j - 1);
          }
          else if (matrix[i, j] == matrix[i + 1, j])
          {
              // s = s + ".";
              traceback(matrix, seq, i + 1, j);
          }
          else if( (see == true)&&(matrix[i, j] ==matrix[i + 1, j - 1] + 1))
          {
            
             // s[i] = '(';

              ch[i] = '(';
              ch[j] = ')';
              traceback(matrix, seq, i+1, j - 1);
          }
          else if ((see == false)&&(matrix[i, j] ==matrix[i + 1, j - 1]))
          {
              traceback(matrix, seq, i + 1, j - 1);
          }
          
          else{
          for (int k = i + 1; k < j; k++)
          {
              if (matrix[i, j] == matrix[i, k] + matrix[k + 1, j])
              {
                  traceback(matrix, seq, i, k);
                  traceback(matrix, seq, k + 1, j);
              }
          }
          }
          return ch;
      }
        static void Main(string[] args)
        {


            string s1 = "CGGACCCAGACUUUC";
            //string s1 = "CUGACUUCAG";
          //  string s2 = "monica";

            int m = s1.Length ;

             ch = new char[m];
            for (int k = 0; k < m; k++)
            {
                ch[k] = '.';
            }
          //  int n = s2.Length ;
            int [,] M1 = fm(s1, s1);
            M1 = Fill_mat(s1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(M1[i, j]);


                    Console.Write(" ");
                }
                Console.WriteLine();

            }
            string Pair ="";
            char[] c = new char[s1.Length];
               c=traceback(M1,s1,0,s1.Length-1);
               for (int l = 0; l < c.Length;l++ )
               {
                   Console.Write(c[l]);
               }
                   Console.ReadKey();

        }
    }

}

