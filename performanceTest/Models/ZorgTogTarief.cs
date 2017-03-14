using System;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace performanceTest.Models{
    //[Class(NameType = typeof(ZorgTogTarief), Table = TABLENAME, DiscriminatorValueObject = DISCRIMINATOR), Discriminator(TypeType = typeof(short))]
    public class ZorgTogTarief : ZorgTarief {
        public enum SoortZorgEnum {
            Cure = 1,
            GGZ = 2,
            AWBZ = 3,
            Nvt = 4
        }

        public enum TypeZorgaanbiederEnum {
            Instelling = 1,
            Praktijk = 2,
            Zorgverlener = 3
        }

        public const string TABLENAME = "ZorgTogTarief";
        public const short DISCRIMINATOR = 1;

        public const string STR_SOORTZORG = "IndicatieSoortZorg";
        public const string STR_PRESTATIECODELIJST = "PrestatiecodeLijst";
        public const string STR_VERRICHTINGDECLARATIECODE = "DbcDeclaratie";
        public const string STR_TOGTARIEFWERELD = "TogTariefWereld";
        public const string STR_KENMERK = "Kenmerk";
        public const string STR_DBCDECLARERENDSPECIALISME = "DbcDeclarerendSpecialisme";
        public const string STR_KOSTENSOORT = "SoortTarief"; //SoortTarief is misleidend: eigenschap heet 'Kostensoort' in TOG-standaard
        public const string STR_TARIEFSOORT = "TypeTarief"; //TypeTarief is misleidend: eigenschap heet 'TariefSoort' in TOG-standaard
        public const string STR_ISMZTECHNIEKKOSTENTARIEF = "IsMZTechniekkostenTarief";

        //[ManyToOne]
        public virtual ZorgTogTariefWereld TogTariefWereld { get; set; }

        //[Property]
        public virtual short? IndicatieSoortZorg { get; set; }
        
        //[Property]
        public virtual short? DbcDeclarerendSpecialisme { get; set; }

        //[Property(Length = 20)]
        public virtual string Kenmerk { get; set; }

        //[Property(Column = STR_KOSTENSOORT)]
        public virtual short? KostenSoort { get; set; }

        //[Property(Column = STR_TARIEFSOORT)]
        public virtual short TariefSoort { get; set; }

        //[Property]
        public virtual bool IsMZTechniekkostenTarief { get; set; }

        //[Property]
        public virtual byte? BtwPercentage { get; set; }
    }

    public class ZorgTogTariefMap : ClassMapping<ZorgTogTarief> {
        public ZorgTogTariefMap() {
            DiscriminatorValue(1);
            
            Table(nameof(ZorgTogTarief));

            Id(zt => zt.Id, mapper => mapper.Generator(Generators.Native));
            Property(zt => zt.Begindatum);
            Property(zt => zt.Einddatum);
            Property(zt => zt.Vervaldatum);
            Property(zt => zt.Importdatum);
            Property(zt => zt.IndicatieDebetCredit, m => m.Length(1));
            Property(zt => zt.Bedrag);

            ManyToOne(ztt => ztt.TogTariefWereld);
            Property(ztt => ztt.IndicatieSoortZorg);
            Property(ztt => ztt.DbcDeclarerendSpecialisme);
            Property(ztt => ztt.Kenmerk, m => m.Length(20));
            Property(ztt => ztt.KostenSoort, m => m.Column("SoortTarief"));
            Property(ztt => ztt.TariefSoort, m => m.Column("TypeTarief"));
            Property(ztt => ztt.IsMZTechniekkostenTarief);
            Property(ztt => ztt.BtwPercentage);
        }
    }
}