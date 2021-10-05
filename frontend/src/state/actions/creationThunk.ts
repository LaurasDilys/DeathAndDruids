import API from '../../domain/Api';
import { getOpenedMonsterAction } from './creationActions'

export const getOpenedMonster = () => (dispatch) => {
  API.get("creation/openedmonster")
    .then(res => dispatch(getOpenedMonsterAction(res.data)))
    .catch(err => console.log(err));
}

export const newMonster = () => (dispatch) => {
  API.post("creation/new")
    .then(() => dispatch(getOpenedMonster()))
    .catch(err => console.log(err));
}