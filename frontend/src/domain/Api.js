import axios from 'axios';

const commonData = { monsters: ["(only beasts, for now)"] }

const stateTemplate = {

  // Entities
  monsters: [], // id, name, init, type="monster", || bool InCombat, bool InCreation
  players: [], // {id, name, init, type="player",  ||  int? combatId

  opened_monster: [1], // id, name, init, int? sourceId (monsterId), bool Saved

  m_copies_in_combat: [],
  combat: [ "selectedId", "m_copies[]", "players[]" ], // id, sourceId (m_copy_in_combat / player), type (monster / player), initiative, InitiativeOrder, IsSelected


  // React store
  monsters: [],
  players: [],

  openedMonster: null,

  selectedCombatTab: 1,
  creaturesInCombat: [],


  // CREATION
  // can delete only when opened
  c_copies_in_creation: [], // id, id from characters, bool InCreation, bool InCombat, bool Saved, bool Selected, int? CreationOrder, int? InitiativeOrder
  m_copies_in_creation: [], // id, id(=0) from monsters,

  // COMBAT
  // onInitiativeChange:
  // const creaturesWithSameInitiative = creatures.filter(c => c.initiative === this.initiative);
  // if (creaturesWithSameInitiative.length > 1) {
  //   creaturesWithSameInitiative.forEach => add to array { id (if monster, it's monster_in_combat id), type (character/monster/player), initiative, InitiativeOrder }
  //   and dispatch (only to backend – state doesn't change here)
  // } else dispatch only this initiative change
  characters_in_combat: [], // id, id from characters, bool Saved, bool Selected, int InitiativeOrder
  players_in_combat: [], // id, id from players, name, init 
  // on load – player.selected = false
  // add ("", ""init);
  // onChange: oldValue === "" ? createPlayer : editPlayer; add ("", ""init);
  // else newValue === "" ? delete this; dispatch(deletePlayer); ("", "") becomes ("", this init)
}

const host = "https://localhost:44351/api/";
const timeout = 3000; // How long of a wait for response is too long

const API = axios.create({
  baseURL: host,
  timeout: timeout,
});

export default API;
