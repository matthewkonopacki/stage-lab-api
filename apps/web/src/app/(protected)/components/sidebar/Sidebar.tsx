import {
  DashboardOutlinedIcon,
  EventOutlinedIcon,
  FolderOpenOutlinedIcon,
  ForumOutlinedIcon,
  LocationOnOutlinedIcon,
  LogoutOutlinedIcon,
  SettingsOutlinedIcon,
  TheaterComedyIcon,
} from '@/app/components/Icons';
import { auth, signOut } from '@/auth';
import { getProductions } from '@/lib/api';
import SidebarLinks from '@/app/(protected)/components/sidebar/SidebarLinks';

export default async function Sidebar() {
  const buttons: Array<{
    id: number;
    name: string;
    icon: React.ElementType;
    href: string;
  }> = [
    { id: 1, name: 'Dashboard', icon: DashboardOutlinedIcon, href: '/' },
    {
      id: 2,
      name: 'Projects',
      icon: FolderOpenOutlinedIcon,
      href: '/projects',
    },
    { id: 3, name: 'Events', icon: EventOutlinedIcon, href: '/events' },
    {
      id: 4,
      name: 'Locations',
      icon: LocationOnOutlinedIcon,
      href: '/locations',
    },
    {
      id: 5,
      name: 'Social Feed',
      icon: ForumOutlinedIcon,
      href: '/social-feed',
    },
  ];

  const session = await auth();
  console.log(session);

  let projects: Array<{ description: string; id: number }> | undefined;

  if (session?.accessToken != null && session.user?.id != null) {
    projects = await getProductions(session.accessToken);
    console.log(projects);
  }
  const logOut = async () => {
    'use server';
    await signOut();
  };

  return (
    <aside className="sidebar flex">
      <div className="m-4 flex-1 flex flex-col justify-between">
        <div className="flex flex-col gap-8">
          <div className="flex items-center gap-4">
            <div className="size-8 bg-primary flex items-center justify-center rounded-lg text-slate-100 shadow-md shadow-primary/40">
              <TheaterComedyIcon className="!h-5 !w-5"></TheaterComedyIcon>
            </div>
            <h1 className="text-2xl font-bold text-slate-900 tracking-tight">
              StageLab
            </h1>
          </div>
          <SidebarLinks buttons={buttons} />
        </div>
        <div className="bg-white/50 rounded-xl w-full p-4 border border-slate-200">
          <div className="flex gap-3 mb-3">
            <div className="flex justify-center items-center size-10 rounded-full border-2 border-primary/20 bg-cover bg-center bg-blue-100 font-black text-slate-700">
              {(session?.user.firstName[0] ?? '') +
                (session?.user.lastName[0] ?? '')}
            </div>
            <div className="flex flex-col">
              <span className="text-sm font-bold truncate text-slate-900">
                {`${session?.user.firstName} ${session?.user.lastName}`}
              </span>
              <span className="text-xs text-slate-500 truncate">
                {session?.user.role}
              </span>
            </div>
          </div>
          <button className="w-full text-xs font-bold py-2 bg-white border border-slate-200 rounded-lg hover:bg-slate-50 transition-colors flex items-center justify-center gap-2 text-slate-700 mb-3">
            <SettingsOutlinedIcon className="!h-4 !w-4" />
            <span>Settings</span>
          </button>
          <button
            onClick={logOut}
            className="w-full text-xs font-bold py-2 bg-white border border-slate-200 rounded-lg hover:bg-slate-50 transition-colors flex items-center justify-center gap-2 text-slate-700"
          >
            <LogoutOutlinedIcon className="!h-4 !w-4" />
            <span>Log Out</span>
          </button>
        </div>
      </div>
    </aside>
  );
}
