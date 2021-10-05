import * as actionTypes from './actionTypes';

export const getOpenedMonsterAction = props => ({
  type: actionTypes.GET_OPENED_MONSTER,
  payload: props
})