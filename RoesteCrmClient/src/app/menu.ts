export class MenuModel {
  name: string = '';
  icon: string = '';
  url: string = '';
  isTitle: boolean = false;
  subMenus: MenuModel[] = [];
}
export const Menus: MenuModel[] = [
  {
    name: 'Anasayfa',
    icon: 'far fa-solid fa-home',
    url: '/',
    isTitle: false,
    subMenus: [],
  },
];
