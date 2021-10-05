import API from '../../domain/Api';
import { getOpenedMonsterAction } from './creationActions'
import { getMonsters } from './monstersThunk';

export const getOpenedMonster = () => (dispatch) => {
  API.get("creation/get")
    .then(res => dispatch(getOpenedMonsterAction(res.data)))
    .catch(err => console.log(err));
}

export const newMonster = () => (dispatch) => {
  API.post("creation/new")
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just created
    .catch(err => console.log(err));
}

export const saveMonster = () => (dispatch) => {
  API.put("creation/save")
    .then(() => dispatch(getMonsters())) // updates saved monsters after
    .catch(err => console.log(err));
}