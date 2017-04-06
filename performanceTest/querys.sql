 --gph
 --Result = SessionFactory.GetCurrentSession()
 --               .QueryOver<ZorgGphTariefWereld>()
 --               .Where(z => z.GphCode == code)
 --               .Fetch(z => z.Tarieven).Eager
 --               .FutureValue().Value;
 declare @code int = 0

 select top 10 *
 from ZorgGphTarief z 
 inner join ZorgPrestatieTariefWereld zw on zw.Id = z.GphTariefWereld
 where zw.class = 4 
 and z.GphCode = @code
 

 --ifm
 --Result = SessionFactory.GetCurrentSession()
 --               .QueryOver<ZorgIfmTariefWereld>()
 --               .Where(z => z.Artikelnummer == artikelnummer)
 --               .Fetch(z => z.Tarieven).Eager
 --               .FutureValue().Value;
 declare @artikelnummer int = 0

 select top 10 *
 from ZorgIfmTarief z 
 inner join ZorgPrestatieTariefWereld zw on zw.id = z.IfmTariefWereld
 where zw.class = 3 
 and z.Artikelnummer = @artikelnummer

 --tog
 --Result = SessionFactory.GetCurrentSession().QueryOver<ZorgTogTariefWereld>()
 --                   .Where(t => t.Prestatiecodelijst == prestatiecodelijst.Code)
 --                   .And(t => t.DbcDeclaratiecode == dbcDeclaratiecode)
 --                   .Fetch(t => t.Tarieven).Eager
 --                   .FutureValue().Value;
 declare @dbcdeclaratiecode varchar(max) = 'H40'
 declare @prestatiecodelijst smallint = 10

 select *
 from ZorgPrestatieTariefWereld zw 
 inner join ZorgTogTarief z on zw.id = z.TogTariefWereld
 where zw.class = 1 
 and zw.DbcDeclaratiecode = @dbcdeclaratiecode
 and zw.Prestatiecodelijst = @prestatiecodelijst


 select top 10 *
 from ZorgPrestatieTariefWereld zw 
 inner join ZorgTogTarief z on zw.id = z.TogTariefWereld
 where zw.class = 1 --TOG
 and zw.DbcDeclaratiecode = @dbcdeclaratiecode
 and zw.Prestatiecodelijst is null