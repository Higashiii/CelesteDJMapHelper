using Microsoft.Xna.Framework;
using Celeste.Mod.DJMapHelper.Cutscenes;
using Monocle;
namespace Celeste.Mod.DJMapHelper.Triggers
{
    public class PayphoneCallTrigger: Trigger 
    {
        private string dialogEntry;
        private bool endLevel;
        private bool answer;

        public PayphoneCallTrigger(EntityData data, Vector2 offset) : base(data, offset) {
            dialogEntry = data.Attr("dialogId");
            endLevel = data.Bool(nameof(endLevel));
            answer = data.Bool(nameof(answer));
        }


        public override void OnEnter(Player player) {
            base.OnEnter(player);
            RemoveSelf();

            Session session = player.SceneAs<Level>().Session;
            if (session.GetFlag(dialogEntry)) {
                return;
            }
            session.SetFlag(dialogEntry);
            player.Scene.Add(new CS_PayphoneCall(player, dialogEntry, endLevel, answer));
        }
    }
}