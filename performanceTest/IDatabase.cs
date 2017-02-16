using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest {
    interface IDatabase
    {
        
        void ClearDb();
        void FillDb();
        void CreateDb();

        void Create(int amount);
        void Read(int amount);
        void Update(int amount);
        void Delete(int amount);
    }
}
