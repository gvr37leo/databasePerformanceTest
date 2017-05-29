using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace performanceTest {
    internal interface IDatabase{
        string Dbname { get; set;}
        string Tablename { get; set; }
        void ClearDb();
        void FillDb(int amount);
        void CreateDb();

        void ManyJoins();
        void ManySmallQuerys();
        void ForceZboSpecific();
        Task ForceZboZorgvoorwaarden();
        Task ForceZboZorgvoorwaarden(List<string> dekkingsCodes);
        void IndexedSearch();
        void NoIndexSearch();
        void EmbeddedVsJoin();

        void Create();
        void Read();
        void Update();
        void Delete();
    }
}
