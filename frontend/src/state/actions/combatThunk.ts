import API from "../../domain/Api";

export const startCombat = (combatRequest) => (dispatch) => {
  API.post("combat/start", combatRequest)
    // .then(() => dispatch(getCombatMonsters()))
    .catch(err => console.log(err));
}