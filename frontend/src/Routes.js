import Combat from './components/Combat/Combat';
import Creation from './components/Creation/Creation';
import AboutPage from './components/AboutPage/AboutPage';

const Routes = [
  {
    title: "About",
    path: "/",
    getComponent: () => {return AboutPage}
  },
  {
    title: "Creation",
    path: "/creation",
    getComponent: () => {return Creation}
  },
  {
    title: "Combat",
    path: "/combat",
    getComponent: () => {return Combat}
  },
  
]

export default Routes;