import API from '../../domain/Api';
import { getMonstersAction } from './monstersActions';
import { getOpenedMonster } from './creationThunk';

export const getMonsters = () => (dispatch) => {
  API.get("monsters/get")
    .then(res => dispatch(getMonstersAction(res.data)))
    .catch(err => console.log(err));
}

export const patchMonster = (patchRequest) => (dispatch) => {
  API.patch("monsters/patch", patchRequest)
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just patched
    .catch(err => console.log(err));
}