'use client';

import dynamic from 'next/dynamic';

export const NotificationsNoneIcon = dynamic(
  () => import('@mui/icons-material/NotificationsNone'),
  { ssr: false },
);

export const HelpOutlineIcon = dynamic(
  () => import('@mui/icons-material/HelpOutline'),
  { ssr: false },
);

export const SearchIcon = dynamic(() => import('@mui/icons-material/Search'), {
  ssr: false,
});

export const TheaterComedyIcon = dynamic(
  () => import('@mui/icons-material/TheaterComedy'),
  { ssr: false },
);

export const DashboardOutlinedIcon = dynamic(
  () => import('@mui/icons-material/DashboardOutlined'),
  { ssr: false },
);

export const FolderOpenOutlinedIcon = dynamic(
  () => import('@mui/icons-material/FolderOpenOutlined'),
  { ssr: false },
);

export const EventOutlinedIcon = dynamic(
  () => import('@mui/icons-material/EventOutlined'),
  { ssr: false },
);

export const LocationOnOutlinedIcon = dynamic(
  () => import('@mui/icons-material/LocationOnOutlined'),
  { ssr: false },
);

export const ForumOutlinedIcon = dynamic(
  () => import('@mui/icons-material/ForumOutlined'),
  { ssr: false },
);

export const SettingsOutlinedIcon = dynamic(
  () => import('@mui/icons-material/SettingsOutlined'),
  { ssr: false },
);

export const LogoutOutlinedIcon = dynamic(
  () => import('@mui/icons-material/LogoutOutlined'),
  { ssr: false },
);
