using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class BattleUIStateMachine {
    public class BattleUI_AugmentSkill : BattleUIStateMachine.BattleUIState {
        public override void Enter(BattleUIStateInput i) {
            base.Enter(i);
            RunPreAnimation();
        }
        
        public override void Update() {
            base.Update();
            int input = MySM.CheckInput();
            if (input == 0 || input == 2) {
                Input.AnimationHandler.skillWindow.ButtonSelect(input != 0);
            } else if (input == 1) {
                MySM._battleStateMachine.AugmentSkill(Input.actor.BonbonInventory[Input.slot]);
                MySM._battleStateMachine.SwitchToTargetSelect(Input.AnimationHandler.skillWindow.ConfirmSkill());
                MySM.Transition<BattleUI_TargetSelect>();
            } else if (input == 3) {
                MySM.Transition<BattleUI_BonbonMenu>();
                Input.slot = -1;
            }
        }

        public override void Exit(BattleUIStateInput i) {
            base.Exit(i);
            RunPostAnimation();
        }
        
        #region Animations

        protected override void RunPreAnimation() {
            base.RunPreAnimation();
            Input.AnimationHandler.skillWindow.Initialize(0.5f, Input.actor);
        }

        protected override void RunPostAnimation() {
            base.RunPostAnimation();
            Input.AnimationHandler.skillWindow.ToggleMainDisplay(false);
            Input.slot = -1;
        }

        #endregion Animations
    }
}
