import API from '../../domain/Api';
import { getMonstersAction } from './monstersActions';
import { getOpenedMonster } from './creationThunk';
import { getCombatants } from './combatThunk';

export const getMonsters = () => (dispatch) => {
  API.get("monsters/get")
    .then(res => dispatch(getMonstersAction(res.data)))
    .catch(err => console.log(err));
}

export const patchMonster = (patchRequest) => (dispatch) => {
  API.patch("monsters/patch", patchRequest)
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just patched
    .then(() => dispatch(getCombatants())) // in case a combatant was patched instead
    .catch(err => console.log(err));
}