import {
  NotificationsNoneIcon,
  HelpOutlineIcon,
  SearchIcon,
  TheaterComedyIcon,
  EventOutlinedIcon,
  LocationOnOutlinedIcon,
  ForumOutlinedIcon, DashboardOutlinedIcon, FolderOpenOutlinedIcon, SettingsOutlinedIcon, LogoutOutlinedIcon
} from '@/app/components/Icons';
import { auth, signOut } from '@/auth';
import { getProductions, getUserEvents } from '@/lib/api';

export default async function ProtectedLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const session = await auth();
  console.log(session)

  let events: Array<{ description: string; id: number; }> | undefined;
  let projects: Array<{description: string; id: number}> | undefined;

  if (session?.accessToken != null && session.user?.id != null) {
    events = await getUserEvents(session.accessToken, session.user.id);
    projects = await getProductions(session.accessToken);
    console.log(projects);
  }

  const buttons: Array<{id: number, name: string; icon: React.ElementType }> = [
    { id: 1, name: 'Dashboard', icon: DashboardOutlinedIcon },
    { id: 2, name: 'Projects', icon: FolderOpenOutlinedIcon },
    { id: 3, name: 'Events', icon: EventOutlinedIcon },
    { id: 4, name: 'Locations', icon: LocationOnOutlinedIcon },
    { id: 5, name: 'Social Feed', icon: ForumOutlinedIcon },
  ];

  const logOut = async () => {
    'use server';
    await signOut();
  }

  return (
    <div className="flex h-screen w-full">
      <aside className="sidebar flex">
        <div className="m-4 flex-1 flex flex-col justify-between">
          <div className="flex flex-col gap-8">
            <div className="flex items-center gap-4">
              <div className="size-10 bg-primary flex items-center justify-center rounded-lg text-slate-100">
                <TheaterComedyIcon className="size-8"></TheaterComedyIcon>
              </div>
              <h1 className="text-2xl font-bold text-slate-900 tracking-tight">
                StageLab
              </h1>
            </div>
            <div className="flex flex-col gap-1">
              {buttons.map((button) => (
                <div
                  key={button.id}
                  className="flex items-center gap-2 px-3 py-2.5 text-slate-700 font-900 hover:bg-primary/5 hover:text-primary rounded-lg transition-all group"
                >
                  <button.icon className="!h-5 !w-5"></button.icon>
                  <h1 className="text-lg tracking-tight">{button.name}</h1>
                </div>
              ))}
            </div>
          </div>
          <div className="bg-white/50 rounded-xl w-full p-4 border border-slate-200">
            <div className="flex gap-3 mb-3">
              <div className="flex justify-center items-center size-10 rounded-full border-2 border-primary/20 bg-cover bg-center bg-blue-100 font-black text-slate-700">{(session?.user.firstName[0] ?? '') + (session?.user.lastName[0] ?? '')}</div>
              <div className="flex flex-col">
                <span className="text-sm font-bold truncate text-slate-900">
                  {`${session?.user.firstName} ${session?.user.lastName}`}
                </span>
                <span className="text-xs text-slate-500 truncate">{session?.user.role}</span>
              </div>
            </div>
            <button className="w-full text-xs font-bold py-2 bg-white border border-slate-200 rounded-lg hover:bg-slate-50 transition-colors flex items-center justify-center gap-2 text-slate-700 mb-3">
              <SettingsOutlinedIcon className="!h-4 !w-4" />
              <span>Settings</span>
            </button>
            <button onClick={logOut} className="w-full text-xs font-bold py-2 bg-white border border-slate-200 rounded-lg hover:bg-slate-50 transition-colors flex items-center justify-center gap-2 text-slate-700">
              <LogoutOutlinedIcon className="!h-4 !w-4" />
              <span>Log Out</span>
            </button>
          </div>
        </div>
      </aside>
      <div className="flex flex-col flex-1 h-full">
        <header className="top-bar flex px-8">
          <div className="flex flex-1 items-center">
            <div className="relative w-full max-w-xl">
              <SearchIcon className="size-4 text-slate-400 absolute left-3 top-1/5"></SearchIcon>
              <input
                className="w-full bg-slate-100 border-none rounded-lg py-2 pl-10 pr-4 text-sm focus:ring-2 focus:ring-primary placeholder:text-slate-400"
                placeholder="Search events, people, or productions..."
              />
            </div>
          </div>
          <div className="flex items-center gap-4 align-end">
            <button className="size-10 flex items-center justify-center rounded-lg bg-slate-100 text-slate-600 hover:bg-slate-200 transition-colors cursor-pointer">
              <NotificationsNoneIcon className="!h-6 !w-6"></NotificationsNoneIcon>
            </button>
            <button className="size-10 flex items-center rounded-lg justify-center bg-slate-100 text-slate-600 hover:bg-slate-200 transition-colors cursor-pointer">
              <HelpOutlineIcon className="!h-6 !w-6"></HelpOutlineIcon>
            </button>
          </div>
        </header>
        <div className="flex-1 min-h-0 overflow-y-auto m-5">
          {events != null &&
            events.length > 0 &&
            events.map((event) => (
              <div key={event.id.toString()}>{event.description}</div>
            ))}
        </div>
      </div>
    </div>
  );
}