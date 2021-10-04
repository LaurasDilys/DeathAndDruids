import API from '../../domain/Api';
import { getMonstersAction } from './monstersActions';

export const getMonsters = () => (dispatch) => {
  API.get(
    "monsters/get"
  )
    .then(res => dispatch(getMonstersAction(res.data)))
    .catch(err => console.log(err));
}