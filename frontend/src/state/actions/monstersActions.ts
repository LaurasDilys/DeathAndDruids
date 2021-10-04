import * as actionTypes from './actionTypes';

export const getMonstersAction = props => ({
  type: actionTypes.GET_MONSTERS,
  payload: props
})