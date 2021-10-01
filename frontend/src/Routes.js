import CombatTabs from './components/CombatTabs/CombatTabs';
import HomePage from './components/HomePage/HomePage';

const Routes = [
  {
    title: "Home",
    path: "/",
    getComponent: () => {return HomePage}
  },
  {
    title: "Creation",
    path: "/creation",
    getComponent: () => {return HomePage}
  },
  {
    title: "Combat",
    path: "/combat",
    getComponent: () => {return CombatTabs}
  },
  
]

export default Routes;