import API from '../../domain/Api';
import { getOpenedMonster } from './creationThunk';
import { getMonstersAction } from './monstersActions';

export const getMonsters = () => (dispatch) => {
  API.get("monsters/get")
    .then(res => dispatch(getMonstersAction(res.data)))
    .catch(err => console.log(err));
}

// creation and POST
export const openMonster = (key) => (dispatch) => {
  API.get(`monsters/open/${key}`)
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just saved as "opened"
    .catch(err => console.log(err));
}
//

export const deleteOpenedMonster = (key) => (dispatch) => {
  API.delete(`monsters/delete/${key}`)
    .then(() => dispatch(getMonsters()))
    .then(() => openLastMonster())
    .catch(err => console.log(err));
}

// creation and POST
export const openLastMonster = () => (dispatch) => {
  API.get("monsters/openlast")
    .then(() => dispatch(getOpenedMonster()))
    .catch(err => console.log(err));
}
//