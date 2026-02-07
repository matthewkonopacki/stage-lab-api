'use client';
import { usePathname } from 'next/navigation';
import clsx from 'clsx';
import Link from 'next/link';

interface SidebarLinksProps {
  buttons: Array<{
    id: number;
    name: string;
    icon: React.ElementType;
    href: string;
  }>;
}

export default function SidebarLinks({ buttons }: SidebarLinksProps) {
  const pathName = usePathname();

  console.log(pathName);

  const pathNameFunction = (href: string, pathName: string) =>
    pathName === href;

  return (
    <div className="flex flex-col gap-1">
      {buttons.map((button) => (
        <Link
          href={button.href}
          key={button.id}
          className={clsx(
            'flex items-center gap-3 px-1 py-1 font-900 hover:bg-primary/5 hover:text-primary rounded-lg transition-all group',
            pathNameFunction(button.href, pathName) &&
              'bg-primary/5 text-primary',
          )}
        >
          <button.icon className="!h-5 !w-5"></button.icon>
          <h1 className="text-lg tracking-tight">{button.name}</h1>
        </Link>
      ))}
    </div>
  );
}
