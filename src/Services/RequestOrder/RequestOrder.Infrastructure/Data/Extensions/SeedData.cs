using RequestOrder.Domain.Models;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Infrastructure.Data.Extensions;

internal class SeedData
{
    public static IEnumerable<Lab> Labs =>
        new List<Lab>
        {
            Lab.Create(LabId.Of(new Guid("E5C31E02-6D6B-4F6C-81D0-C044E8DF4627")), "LAB1", "WWW.LAB1.COM"),
            Lab.Create(LabId.Of(new Guid("7144FDB1-13D8-4F96-AE65-DF0CFC4A7818")), "LAB2", "WWW.LAB2.COM"),
            Lab.Create(LabId.Of(new Guid("4A4E32B3-EAA8-455D-8AA7-5530624C59F6")), "LAB3", "WWW.LAB3.COM")
        };

    public static IEnumerable<Shipper> Shippers =>
        new List<Shipper>
        {
            Shipper.Create(ShipperId.Of(new Guid("B128701E-D2A4-4414-ADE8-FB87C0021CB8")), "SHIPPER1", "WWW.SHIPPER1.COM"),
            Shipper.Create(ShipperId.Of(new Guid("CD927D26-5CF0-47C5-B8BA-58F681351D3E")), "SHIPPER2", "WWW.SHIPPER2.COM"),
            Shipper.Create(ShipperId.Of(new Guid("028F3FD0-F1C0-445F-995D-48B957F0FFCD")), "SHIPPER3", "WWW.SHIPPER3.COM")
        };

    public static IEnumerable<Patient> Patients =>
        new List<Patient>
        {
            Patient.Create(PatientId.Of(new Guid("CD010EE9-582C-4D86-8043-8C8B858CCAF5")), "Jane", "Bottle", "222.333.4444", DateTime.Parse("11/22/1999"), "F", "323443343"),
            Patient.Create(PatientId.Of(new Guid("A50236D4-BD79-4DB0-91D7-1CAD9B547DA1")), "John", "Drama", "444.555.3333", DateTime.Parse("01/14/2001"), "M", "6754567676"),
            Patient.Create(PatientId.Of(new Guid("E0934142-242A-4264-8F8B-8DF7C35B2CB0")), "Paul", "Rofello", "111.111.3333", DateTime.Parse("07/22/1950"), "M", "1234326564"),
            Patient.Create(PatientId.Of(new Guid("60B2E6E3-2D79-49D4-8673-5A8FE4809936")), "Anna", "Maverick", "888.999.6666", DateTime.Parse("12/08/1980"), "F", "2348905645")
        };

    public static IEnumerable<Provider> Providers =>
        new List<Provider>
        {
            Provider.Create(ProviderId.Of(new Guid("CAAF5A7D-970D-4126-B8CA-AE53FAB721B7")), "PROVIDER_1", "305.456.2132"),
            Provider.Create(ProviderId.Of(new Guid("85E20ADA-1BCB-4297-8BD3-2826379E4700")), "PROVIDER_2", "305.456.2132"),
            Provider.Create(ProviderId.Of(new Guid("D26F3FB8-3AAE-4A36-82B5-09B14BC411CD")), "PROVIDER_3", "453.548.9786"),
            Provider.Create(ProviderId.Of(new Guid("CD9CB880-B2B9-4878-839C-589036975E54")), "PROVIDER_4", "767.332.7676"),
            Provider.Create(ProviderId.Of(new Guid("F6E729FC-5CD8-4450-AC2F-D24556C22CA7")), "PROVIDER_5", "305.434.5665"),
            Provider.Create(ProviderId.Of(new Guid("614F2CE0-CA93-4BB4-9422-4C2EF5808F0B")), "PROVIDER_6", "788.432.2123")
        };

    public static IEnumerable<Technician> Technicians =>
        new List<Technician>
        {
            Technician.Create(TechnicianId.Of(new Guid("8FE56660-DF3A-4C10-B09D-BBD3858A51D3")), "Jackie", "Williams", "111.444.3333"),
            Technician.Create(TechnicianId.Of(new Guid("07D6E661-4766-45F5-84BA-3935BDA57DA7")), "Paula", "Gerth", "666.555.7777"),
            Technician.Create(TechnicianId.Of(new Guid("BC314E92-E662-4954-97F3-64D25198E307")), "James", "Madison", "333.444.2222"),
            Technician.Create(TechnicianId.Of(new Guid("D73FA811-ACD1-40E7-B79A-946EA59681BE")), "Neo", "Snatch", "666.555.4444")
        };

    public static IEnumerable<Procedure> Procedures =>
        new List<Procedure>
        {
            Procedure.Create(ProcedureId.Of(new Guid("9A1E3691-B1FD-4F2C-A67F-383AAE88B4EC")), "CODE_1", "NAME_1", "SPECIMEN_1", "CPT_1"),
            Procedure.Create(ProcedureId.Of(new Guid("D2B9AA9E-12B1-4870-8641-F96D60BA9461")), "CODE_2", "NAME_2", "SPECIMEN_2", "CPT_2"),
            Procedure.Create(ProcedureId.Of(new Guid("50B8041D-25BE-414B-9C65-028C56664262")), "CODE_3", "NAME_3", "SPECIMEN_3", "CPT_3"),
            Procedure.Create(ProcedureId.Of(new Guid("98F35BCF-13E6-490F-9226-C6B09247A2A7")), "CODE_4", "NAME_4", "SPECIMEN_4", "CPT_4")
        };

    public static IEnumerable<Order> Orders
    {
        get
        {
            // ORDER 1
            var address1 = Address.Of("123 NE 32 ST", string.Empty, "North Miami", "FL", "33162", "USA");
            var payment1 = Payment.Of(0, DateTime.Now, 0, DateTime.Now, 200, DateTime.Now, 400, DateTime.Now);
            var insurance1 = Insurance.Of("United Health Care", "333222", "774466363");
            var order1 = Order.Create(
                OrderId.Of(new Guid("2A09B11C-A1B7-48EA-9EC1-3028D0FEB24B")),
                OrderNumber.Of("555555"),
                TechnicianId.Of(new Guid("8FE56660-DF3A-4C10-B09D-BBD3858A51D3")),
                ProviderId.Of(new Guid("CAAF5A7D-970D-4126-B8CA-AE53FAB721B7")),
                PatientId.Of(new Guid("CD010EE9-582C-4D86-8043-8C8B858CCAF5")),
                LabId.Of(new Guid("E5C31E02-6D6B-4F6C-81D0-C044E8DF4627")),
                ShipperId.Of(new Guid("B128701E-D2A4-4414-ADE8-FB87C0021CB8")),
                address1,
                insurance1,
                payment1);
            order1.Add(ProcedureId.Of(new Guid("9A1E3691-B1FD-4F2C-A67F-383AAE88B4EC")), 1, 120);
            order1.Add(ProcedureId.Of(new Guid("D2B9AA9E-12B1-4870-8641-F96D60BA9461")), 2, 115);

            // ORDER 2
            var address2 = Address.Of("777 NW 33 ST", string.Empty, "North Miami", "FL", "33162", "USA");
            var payment2 = Payment.Of(0, DateTime.Now, 50, DateTime.Now, 90, DateTime.Now, 0, DateTime.Now);
            var insurance2 = Insurance.Of("United Health Care", "333222", "774466363");
            var order2 = Order.Create(
                OrderId.Of(new Guid("88206EB7-9FEF-4F2E-91DB-9D4829C6DCF0")),
                OrderNumber.Of("111111"),
                TechnicianId.Of(new Guid("BC314E92-E662-4954-97F3-64D25198E307")),
                ProviderId.Of(new Guid("F6E729FC-5CD8-4450-AC2F-D24556C22CA7")),
                PatientId.Of(new Guid("A50236D4-BD79-4DB0-91D7-1CAD9B547DA1")),
                LabId.Of(new Guid("E5C31E02-6D6B-4F6C-81D0-C044E8DF4627")),
                ShipperId.Of(new Guid("B128701E-D2A4-4414-ADE8-FB87C0021CB8")),
                address2,
                insurance2,
                payment2);
            order2.Add(ProcedureId.Of(new Guid("50B8041D-25BE-414B-9C65-028C56664262")), 1, 120);
            order2.Add(ProcedureId.Of(new Guid("9A1E3691-B1FD-4F2C-A67F-383AAE88B4EC")), 2, 115);

            // ORDER 3
            var address3 = Address.Of("129 Scooby Doo Ave", string.Empty, "South Miami", "FL", "33162", "USA");
            var payment3 = Payment.Of(0, DateTime.Now, 110, DateTime.Now, 330, DateTime.Now, 0, DateTime.Now);
            var insurance3 = Insurance.Of("United Health Care", "333222", "774466363");
            var order3 = Order.Create(
                OrderId.Of(new Guid("D7E16E23-3282-4F10-97D3-CBFB724E4DC4")),
                OrderNumber.Of("222222"),
                TechnicianId.Of(new Guid("07D6E661-4766-45F5-84BA-3935BDA57DA7")),
                ProviderId.Of(new Guid("614F2CE0-CA93-4BB4-9422-4C2EF5808F0B")),
                PatientId.Of(new Guid("60B2E6E3-2D79-49D4-8673-5A8FE4809936")),
                LabId.Of(new Guid("7144FDB1-13D8-4F96-AE65-DF0CFC4A7818")),
                ShipperId.Of(new Guid("CD927D26-5CF0-47C5-B8BA-58F681351D3E")),
                address3,
                insurance3,
                payment3);
            order3.Add(ProcedureId.Of(new Guid("50B8041D-25BE-414B-9C65-028C56664262")), 2, 115);

            // ORDER 4
            var address4 = Address.Of("KANI Chill RD", string.Empty, "Miami Beach", "FL", "33156", "USA");
            var payment4 = Payment.Of(0, DateTime.Now, 200, DateTime.Now, 0, DateTime.Now, 500, DateTime.Now);
            var insurance4 = Insurance.Of("United Health Care", "333222", "774466363");
            var order4 = Order.Create(
                OrderId.Of(new Guid("E0E09C68-35A4-46A1-986C-6469600BC4B0")),
                OrderNumber.Of("333333"),
                TechnicianId.Of(new Guid("07D6E661-4766-45F5-84BA-3935BDA57DA7")),
                ProviderId.Of(new Guid("F6E729FC-5CD8-4450-AC2F-D24556C22CA7")),
                PatientId.Of(new Guid("E0934142-242A-4264-8F8B-8DF7C35B2CB0")),
                LabId.Of(new Guid("7144FDB1-13D8-4F96-AE65-DF0CFC4A7818")),
                ShipperId.Of(new Guid("CD927D26-5CF0-47C5-B8BA-58F681351D3E")),
                address4,
                insurance4,
                payment4);
            order4.Add(ProcedureId.Of(new Guid("50B8041D-25BE-414B-9C65-028C56664262")), 1, 120);
            order4.Add(ProcedureId.Of(new Guid("98F35BCF-13E6-490F-9226-C6B09247A2A7")), 2, 115);

            // ORDER 5
            var address5 = Address.Of("876 CARL RD", string.Empty, "Scottsdale", "AZ", "85434", "USA");
            var payment5 = Payment.Of(0, DateTime.Now, 90, DateTime.Now, 0, DateTime.Now, 90, DateTime.Now);
            var insurance5 = Insurance.Of("United Health Care", "333222", "774466363");
            var order5 = Order.Create(
                OrderId.Of(new Guid("D651210B-FDFF-4841-92CC-F2EF19E7A3B9")),
                OrderNumber.Of("444444"),
                TechnicianId.Of(new Guid("D73FA811-ACD1-40E7-B79A-946EA59681BE")),
                ProviderId.Of(new Guid("614F2CE0-CA93-4BB4-9422-4C2EF5808F0B")),
                PatientId.Of(new Guid("60B2E6E3-2D79-49D4-8673-5A8FE4809936")),
                LabId.Of(new Guid("4A4E32B3-EAA8-455D-8AA7-5530624C59F6")),
                ShipperId.Of(new Guid("028F3FD0-F1C0-445F-995D-48B957F0FFCD")),
                address5,
                insurance5,
                payment5);
            order5.Add(ProcedureId.Of(new Guid("D2B9AA9E-12B1-4870-8641-F96D60BA9461")), 2, 115);

            // ORDER 6
            var address6 = Address.Of("8677 NW 22 ST", string.Empty, "Phoenix", "AZ", "876567", "USA");
            var payment6 = Payment.Of(0, DateTime.Now, 100, DateTime.Now, 0, DateTime.Now, 100, DateTime.Now);
            var insurance6 = Insurance.Of("United Health Care", "333222", "774466363");
            var order6 = Order.Create(
                OrderId.Of(new Guid("4EA9213D-B47E-442F-B784-7E36CB49CA39")),
                OrderNumber.Of("666666"),
                TechnicianId.Of(new Guid("8FE56660-DF3A-4C10-B09D-BBD3858A51D3")),
                ProviderId.Of(new Guid("CAAF5A7D-970D-4126-B8CA-AE53FAB721B7")),
                PatientId.Of(new Guid("CD010EE9-582C-4D86-8043-8C8B858CCAF5")),
                LabId.Of(new Guid("4A4E32B3-EAA8-455D-8AA7-5530624C59F6")),
                ShipperId.Of(new Guid("028F3FD0-F1C0-445F-995D-48B957F0FFCD")),
                address6,
                insurance6,
                payment6);
            order6.Add(ProcedureId.Of(new Guid("98F35BCF-13E6-490F-9226-C6B09247A2A7")), 1, 120);
            order6.Add(ProcedureId.Of(new Guid("D2B9AA9E-12B1-4870-8641-F96D60BA9461")), 2, 115);

            // add all 6 orders
            return new List<Order> { order1, order2, order3, order4, order5, order6 };
        }
    }
}
