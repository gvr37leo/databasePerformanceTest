using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace performanceTest.Models{
    public class ZorgTarief {
        public const string STR_CLASS = "class";
        public const string STR_BEDRAG = "Bedrag";
        public const string STR_BEGINDATUM = "Begindatum";
        public const string STR_EINDDATUM = "Einddatum";
        public const string STR_VERVALDATUM = "Vervaldatum";
        public const string STR_IMPORTDATUM = "Importdatum";
        public const string STR_INDICATIEDEBETCREDIT = "IndicatieDebetCredit";
        public const string STR_ID = "Id";

        //[Id(-2, Name = STR_ID), Generator(-1, Class = "native")]
        public virtual long? Id { get; set; }

        //[Property]
        public virtual DateTime Begindatum { get; set; }

        //[Property]
        public virtual DateTime? Einddatum { get; set; }

        //[Property]
        public virtual DateTime? Vervaldatum { get; set; }

        //[Property]
        public virtual DateTime? Importdatum { get; set; }

        //[Property(Length = 1)]
        public virtual char? IndicatieDebetCredit { get; set; }

        //[Property]
        public virtual long Bedrag { get; set; }

        public ZorgPrestatieTariefWereld Wereld { get; set; }
    }
}