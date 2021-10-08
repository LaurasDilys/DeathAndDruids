import API from '../../domain/Api';
import { getOpenedMonsterAction } from './creationActions'
import { getMonsters } from './monstersThunk';

export const getOpenedMonster = () => (dispatch) => {
  API.get("creation/get")
    .then(res => dispatch(getOpenedMonsterAction(res.data)))
    .catch(err => console.log(err));
}

export const openLastMonster = () => (dispatch) => {
  API.get("creation/getlast")
    .then(res => dispatch(getOpenedMonsterAction(res.data)))
    .catch(err => console.log(err));
}

export const newMonster = () => (dispatch) => {
  API.post("creation/new")
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just created
    .catch(err => console.log(err));
}

export const patchMonster = (patchRequest) => (dispatch) => {
  API.patch("creation/patch", patchRequest)
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just patched
    .catch(err => console.log(err));
}

export const saveMonster = () => (dispatch) => {
  API.put("creation/save")
    .then(() => dispatch(getOpenedMonster()))
    .then(() => dispatch(getMonsters())) // updates saved monsters after creation is saved
    .catch(err => console.log(err));
}

export const openMonster = (key) => (dispatch) => {
  API.post(`creation/open/${key}`)
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just saved as "opened"
    .catch(err => console.log(err));
}

export const closeMonster = () => (dispatch) => {
  API.delete("creation/close")
    .catch(err => console.log(err));
}

export const deleteOpenedMonster = (key) => (dispatch) => {
  API.delete("creation/delete")
    .then(() => dispatch(getMonsters()))
    .then(() => dispatch(openLastMonster())) // opens last created monster
    .catch(err => console.log(err));
}