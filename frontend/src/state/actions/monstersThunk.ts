import API from '../../domain/Api';
import { getOpenedMonster } from './creationThunk';
import { getMonstersAction } from './monstersActions';

export const getMonsters = () => (dispatch) => {
  API.get("monsters/get")
    .then(res => dispatch(getMonstersAction(res.data)))
    .catch(err => console.log(err));
}

export const deleteOpenedMonster = (key) => (dispatch) => {
  API.delete("creation/delete")
    .then(() => dispatch(getMonsters()))
    .then(() => dispatch(openLastMonster())) // opens last created monster
    .catch(err => console.log(err));
}

// export const deleteOpenedMonster = (key) => (dispatch) => {
//   API.delete(`monsters/delete/${key}`)
//     .then(() => dispatch(closeOpenedMonster()))
//     .then(() => dispatch(getMonsters()))
//     .then(() => dispatch(openLastMonster())) // opens last created monster
//     .catch(err => console.log(err));
// }

// TO CREATION
export const closeOpenedMonster = () => (dispatch) => {
  API.delete("creation/close")
    .catch(err => console.log(err));
}

export const openMonster = (key) => (dispatch) => {
  API.post(`creation/open/${key}`)
    .then(() => dispatch(getOpenedMonster())) // gets monster that was just saved as "opened"
    .catch(err => console.log(err));
}

export const openLastMonster = () => (dispatch) => {
  API.post("creation/openlast")
    .then(() => dispatch(getOpenedMonster()))
    .catch(err => console.log(err));
}
//