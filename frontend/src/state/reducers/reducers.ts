import { combineReducers } from 'redux';
import type { StateType } from 'typesafe-actions';
import openedMonster from './creationReducer';
import monsters from './monstersReducer'

const reducers = combineReducers({ openedMonster, monsters });
export type RootState = StateType<typeof reducers>;

export default reducers;