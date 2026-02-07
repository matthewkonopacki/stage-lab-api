import {
  HelpOutlineIcon,
  NotificationsNoneIcon,
  SearchIcon,
} from '@/app/components/Icons';

export default function Header() {
  return (
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
  );
}
