import CombatTabs from './components/CombatTabs/CombatTabs';
import Creation from './components/Creation/Creation';
import HomePage from './components/HomePage/HomePage';

const Routes = [
  {
    title: "About",
    path: "/",
    getComponent: () => {return HomePage}
  },
  {
    title: "Creation",
    path: "/creation",
    getComponent: () => {return Creation}
  },
  {
    title: "Combat",
    path: "/combat",
    getComponent: () => {return CombatTabs}
  },
  
]

export default Routes;