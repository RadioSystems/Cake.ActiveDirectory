namespace Cake.ActiveDirectory.Tests
{
    using Fixie;
    using UglyToad.Fixie.DataDriven;

    public class DataDrivenTestConvention : Convention
    {
        public DataDrivenTestConvention()
        {
            Classes.NameEndsWith("Tests");

            Methods.Where(method => method.IsVoid());

            Parameters
                .Add<ProvideTestDataFromInlineData>()
                .Add<ProvideTestDataFromMemberData>();
        }
    }
}
