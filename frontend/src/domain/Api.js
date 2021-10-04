const commonData = { monsters: ["(only beasts, for now)"] }

const stateTemplate = {

  // Entities
  monsters: [], // id, name, init, type="monster", bool InCombat, bool InCreation
  players: [], // {id, name, init, type="player"}

  monster_in_creation: [1], // id, name, init, sourceId(=0) (monster), bool Saved

  combat: ["selectedId", ["combatants"]], // id, sourceId (m_copy_in_combat / player), type (monster / player), initiative, InitiativeOrder, IsSelected
  m_copies_in_combat: [],


  // React store
  allMonsters: [],
  allPlayers: [],

  monsterInCreation: {},

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