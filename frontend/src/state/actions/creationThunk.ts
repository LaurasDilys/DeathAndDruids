import API from '../../domain/Api';
import { getOpenedMonsterAction, newMonsterAction } from './creationActions'

export const getOpenedMonster = () => (dispatch) => {
  API.get(
    "creation/openedmonster"
  )
    .then(res => dispatch(getOpenedMonsterAction(res.data)))
    .catch(err => console.log(err));
}

export const newMonster = () => (dispatch) => {
  API.get(
    "creation/new"
  )
    .then(res => dispatch(newMonsterAction(res.data)))
    .catch(err => console.log(err));
}