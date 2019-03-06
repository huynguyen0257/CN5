using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piggy.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ctrl + K + D =====> Beautify code
            //Ctrl + K + C =====> Comment
            //Ctrl + K + U =====> unComment
            //Ctrl + K + X =====> chọn spinnet
            //Ctrl + D =====> tạo 1 dòng tương tự
            //Alt + lên or xuống =====> di chuyển dòng

            //Keywork:
            //ctor
            //prop
            //cw



            var userIds = new int[] { 0, 1, 1, 2, 2, 3, 3, 4, 5 };
            var newsIds = new int[] { 0, 1, 4, 2, 3, 1, 5, 4, 4 };
            var ratePts = new int[] { 5, 2, 4, 1, 4, 5, 4, 3, 4 };
            
            var maxUserId = int.MinValue;
            for (int i = 0; i < userIds.Length; i++)
            {
                if (maxUserId < userIds[i]) maxUserId = userIds[i];
            }

            var maxNewId = int.MinValue;
            for (int i = 0; i < newsIds.Length; i++)
            {
                if (maxNewId < newsIds[i]) maxNewId = newsIds[i];
            }



            double[,] matrix = new double[maxUserId + 1, maxNewId + 1];



            for (int i = 0; i < userIds.Length; i++)
            {
                var userId = userIds[i];
                var newId = newsIds[i];
                var ratingPoint = ratePts[i];
                matrix[userId, newId] = ratingPoint;
            }
            for (int i = 0; i < maxNewId + 1; i++)
            {
                for (int j = 0; j < maxUserId + 1; j++)
                {
                    System.Console.Write(matrix[j,i]);
                }
                System.Console.WriteLine();
            }
        }
    }
}
