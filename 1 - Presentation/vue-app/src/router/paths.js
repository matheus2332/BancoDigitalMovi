/**
 * Define all of your application routes here
 * for more information on routes, see the
 * official documentation https://router.vuejs.org/en/
 */
export default [
  {
    path: '/',
    redirect: {
      name: 'login'
    }
  },
  {
    path: '/login',
    name: 'login',
    view: 'Login'
  },
  {
    path: '/solicitar-emprestimo',
    name: 'User Profile',
    view: 'UserProfile'
  },
  {
    path: '/meus-emprestimos',
    name: 'Table List',
    view: 'TableList'
  }
]
