using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class BattleUIStateMachine {
    public class BattleUI_BonbonMenu : BattleUIStateMachine.BattleUIState {
        public override void Enter(BattleUIStateInput i) {
            base.Enter(i);
            RunPreAnimation();
        }
        
        public override void Update() {
            base.Update();
            int input = MySM.CheckInput();
            if (input == 0 || input == 2) {
                Debug.Log("checking input");
                Input.AnimationHandler.bonbonWindow.BonbonSelect(input != 0);
            } else if (input == 1) {
                Debug.Log("oof");
            } else if (input == 3) {
                MySM.Transition<InitUIState>();
            }
        }

        public override void Exit(BattleUIStateInput i) {
            base.Exit(i);
            RunPostAnimation();
        }
        
        #region Animations

        protected override void RunPreAnimation() {
            base.RunPreAnimation();
            Input.AnimationHandler.bonbonWindow.Initialize(MySM._battleStateMachine.CurrInput.ActiveActor().BonbonInventory);
        }

        protected override void RunPostAnimation() {
            base.RunPostAnimation();
            Input.AnimationHandler.bonbonWindow.ToggleMainDisplay(false);
        }

        #endregion Animations
    }
}
