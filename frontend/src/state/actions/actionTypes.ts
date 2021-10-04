import { combineReducers } from 'redux';
import type { StateType } from 'typesafe-actions';
import { applyMiddleware, createStore } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import axios from 'axios';

// ../domain/Api.ts
const host = "https://localhost:44351/";
const timeout = 3000; // How long of a wait for response is too long

const API = axios.create({
  baseURL: host,
  timeout: timeout,
});



// actionTypes (here)
export const NEW_CHARACTER = "NEW_CHARACTER";



// action
export const NewCharacterAction = (props) => ({
  type: NEW_CHARACTER,
  payload: props
})



// thunk
export const NewCharacter = () => (dispatch) => {
  API.get(
    "creation/new"
  )
    .then(res => dispatch(NewCharacterAction(res.data)))
    .catch(err => console.log(err));
}



// reducer
type Character = {
  id: number,
  name: string,
  initiative: number,
  hp: number,
  maxHp: number
}

export type CreationState = {
  characters: Character[]
}

const initialState: CreationState = {
  characters: []
}

type CreationAction = {
  type: string;
  payload: Character;
}

export const creationReducer = (state: CreationState = initialState, action: CreationAction): CreationState => {
  switch (action.type) {
    //
    case "TEST":
      let first = state.characters[0];
      first.hp++;
      let rest = state.characters;
      rest.shift();
      return { ...state, characters: [first, ...rest] }
      //
    case NEW_CHARACTER:
      return { ...state, characters: [...state.characters, action.payload] };
    default:
      return state;
  };
};

// reducers.ts
export const reducers = combineReducers({ creationReducer });
export type RootState = StateType<typeof reducers>;

// export default reducers;



// selector
export const getCharacters = (state: RootState): CreationState => state.creationReducer;



// store
export default function configureStore() {

  const middlewareEnhancer = applyMiddleware(thunk);

  const composedEnhancers = composeWithDevTools(middlewareEnhancer);

  const store = createStore(reducers, composedEnhancers);

  return store;
}
