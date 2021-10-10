import API from "../../domain/Api";
import { getCombatantsAction } from "./combatAction";

export const startCombat = (combatRequest) => (dispatch) => {
  API.post("combat/start", combatRequest)
    .then(() => dispatch(getCombatants()))
    .catch(err => console.log(err));
}

export const getCombatants = () => (dispatch) => {
  API.get("combat/get")
    .then((res) => dispatch(getCombatantsAction(res.data)))
    .catch(err => console.log(err));
}

export const deleteCombatant = (key) => (dispatch) => {
  API.delete(`combat/delete/${key}`)
    .then(() => dispatch(getCombatants()))
    .catch(err => console.log(err));
}