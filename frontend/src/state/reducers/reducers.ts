import { combineReducers } from 'redux';
import type { StateType } from 'typesafe-actions';
import creation from './creationReducer';
import monsters from './monstersReducer'

const reducers = combineReducers({ creation, monsters });
export type RootState = StateType<typeof reducers>;

export default reducers;