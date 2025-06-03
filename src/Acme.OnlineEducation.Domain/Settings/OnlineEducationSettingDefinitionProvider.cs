using Volo.Abp.Settings;

namespace Acme.OnlineEducation.Settings;

public class OnlineEducationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OnlineEducationSettings.MySetting1));
    }
}
